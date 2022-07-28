using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject rocketGun;
    [SerializeField] private float aimingSpeed;
    [SerializeField] private float timeWaitToFire;
    [SerializeField] private Vector3 spawnPosition;
    private Animator animator;

    public static bool isAiming;
    public static bool isShooting;
    public static bool hasShot;

    public void Renew()
    {
        Player.isAiming = false;
        Player.isShooting = false;
        Player.hasShot = false;

        transform.position = spawnPosition;
        transform.rotation = Quaternion.identity;
        rocketGun.GetComponent<RocketGun>().Renew();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Renew();
    }

    private void Update()
    {
        animator.SetBool("running", LevelManager.isChangingLevel);

        if (!Gameplay.isPlaying || !Gameplay.isPlayerTurn || LevelManager.isChangingLevel)
            return;

        if (Input.GetMouseButtonDown(0) && !Utility.IsPointerOverUIObject() && !isAiming && !isShooting)
            isAiming = true;

        if (isAiming)
            Aiming();

        if (Input.GetMouseButtonUp(0) && isAiming)
            StartCoroutine(Fire());
    }

    private void Aiming()
    {
        rocketGun.transform.Rotate(0f, 0f, aimingSpeed * Time.deltaTime);
        float angle = Mathf.Clamp(rocketGun.transform.eulerAngles.z, 0f, 90f);
        rocketGun.transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private IEnumerator Fire()
    {
        isAiming = false;
        isShooting = true;

        yield return new WaitForSeconds(timeWaitToFire);

        animator.SetTrigger("fire");
        rocketGun.GetComponent<RocketGun>().Fire();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet" || collision.gameObject.tag == "EnemyBullet")
        {
            gameObject.SetActive(false);
            Gameplay.isGameOver = true;
        }
    }
}