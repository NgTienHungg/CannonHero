using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private Gun gun;
    private Animator animator;
    private Explosion explosion;

    public static bool isAiming;
    public static bool isShooting;
    public static bool hasShot;

    public void Renew()
    {
        Player.isAiming = false;
        Player.isShooting = false;
        Player.hasShot = false;

        transform.position = spawnPosition;
        animator.enabled = true;
        explosion.Renew();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        explosion = GetComponent<Explosion>();

        Player.isAiming = false;
        Player.isShooting = false;
        Player.hasShot = false;
        //Renew();
    }

    private void Start()
    {
        transform.position = spawnPosition;
        animator.enabled = true;
        explosion.Renew();
    }

    private void Update()
    {
        if (!GamePlay.isPlaying)
            return;

        animator.SetBool("running", LevelManager.isChangingLevel);

        if (!GamePlay.isPlayerTurn || LevelManager.isChangingLevel)
            return;

        if (Input.GetMouseButtonDown(0) && !Utility.IsPointerOverUIObject() && !isAiming && !isShooting)
            isAiming = true;

        if (isAiming)
            gun.Aiming();

        if (Input.GetMouseButtonUp(0) && isAiming)
            StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        isAiming = false;
        isShooting = true;

        float timeWaitToFire = 0.05f;
        yield return new WaitForSeconds(timeWaitToFire);

        animator.SetTrigger("fire");
        gun.GetComponent<Gun>().Fire();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet" || collision.gameObject.tag == "EnemyBullet")
            Explode();
    }

    private void Explode()
    {
        //AudioManager.Instance.PlaySound("PlayerExplosion");
        animator.enabled = false; // to make explode
        StartCoroutine(explosion.Explode());
        GamePlay.isPlayerTurn = false;
    }
}