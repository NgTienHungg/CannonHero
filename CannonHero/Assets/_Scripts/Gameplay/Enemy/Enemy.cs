using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private BoxCollider2D headCollider;
    [SerializeField] private BoxCollider2D bodyCollider;
    [SerializeField] private Animator animator;

    [Header("Gun")]
    [SerializeField] private GameObject cannonGun;
    [SerializeField] private float aimingSpeed;
    [SerializeField] private float timeWaitToFire;

    private GameObject player;
    private float targetAngle;
    private bool isAiming, isShooting;
    public bool Hit { get; set; }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isAiming = isShooting = false;
    }

    private void Update()
    {
        if (Hit)
            Explode();

        if (!Gameplay.isPlaying || !Gameplay.isEnemyTurn)
            return;

        if (!isAiming && !isShooting)
        {
            transform.rotation = Quaternion.identity;
            cannonGun.transform.rotation = Quaternion.identity;
            isAiming = true;

            // calculate target angle
            float x = transform.position.x - player.transform.position.x;
            float y = transform.position.y - player.transform.position.y;
            targetAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        }

        if (isAiming)
            Aiming();
    }

    private void Aiming()
    {
        cannonGun.transform.Rotate(0f, 0f, aimingSpeed * Time.deltaTime);

        if (cannonGun.transform.eulerAngles.z >= Mathf.Abs(targetAngle))
            StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        isAiming = false;
        isShooting = true;

        yield return new WaitForSeconds(timeWaitToFire);

        animator.SetTrigger("fire");
        cannonGun.GetComponent<CannonGun>().Fire();
    }

    private void Explode()
    {
        // neu ban trung ca Body va Head => tinh la Body
        // neu BodyCollider con bat => moi tinh la HeadShot
        if (bodyCollider.enabled)
            Gameplay.isHeadShot = true;

        Hit = false;
        headCollider.enabled = false;
        bodyCollider.enabled = false;
        Gameplay.isVictory = true;
    }
}