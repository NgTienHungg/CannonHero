using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BoxCollider2D headCollider;
    [SerializeField] private BoxCollider2D bodyCollider;
    [SerializeField] private GameObject coinEff;
    [SerializeField] private Gun gun;
    private Animator animator;
    private Explosion explosion;

    private GameObject level;
    private GameObject player;
    private float targetAngle;
    private bool isAiming;
    public bool Dead { get; set; }

    public void Renew()
    {
        isAiming = false;
        Dead = false;

        headCollider.enabled = true;
        bodyCollider.enabled = true;

        animator.enabled = true;
        explosion.Renew();
        gun.Renew();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        explosion = GetComponent<Explosion>();
        level = transform.parent.gameObject;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!GamePlay.isPlaying || LevelManager.GetCurrentLevel() != level)
            return;

        if (Dead)
            Explode();

        if (!GamePlay.isEnemyTurn)
            return;

        if (!isAiming)
        {
            transform.rotation = Quaternion.identity;
            gun.transform.rotation = Quaternion.identity;
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
        gun.Aiming();

        if (gun.transform.eulerAngles.z >= Mathf.Abs(targetAngle))
            StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        isAiming = false;
        GamePlay.isEnemyTurn = false;

        float timeWaitToFire = 0.05f;
        yield return new WaitForSeconds(timeWaitToFire);

        animator.SetTrigger("fire");
        gun.Fire();
    }

    private void Explode()
    {
        GamePlay.isVictory = true;

        // neu ban trung ca Body va Head => tinh la Body
        if (bodyCollider.enabled)
            GamePlay.isHeadShot = true;

        headCollider.enabled = false;
        bodyCollider.enabled = false;
        Dead = false;

        StartCoroutine(CoinFalling());
        animator.enabled = false;
        StartCoroutine(explosion.Explode());
    }

    private IEnumerator CoinFalling()
    {
        AudioManager.Instance.PlaySound("Point");

        int coin;
        if (GamePlay.isCrazing)
            coin = Random.Range(12, 15);
        else if (GamePlay.isHeadShot)
            coin = Random.Range(8, 10);
        else
            coin = Random.Range(4, 6);

        ParticleSystem ps = Instantiate(coinEff, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        ps.emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0f, coin) });

        yield return new WaitForSeconds(1f);

        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + coin);
    }
}