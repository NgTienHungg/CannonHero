using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    private Enemy enemy;
    private BoxCollider2D headCollider;

    private void Awake()
    {
        enemy = transform.GetComponentInParent<Enemy>();
        headCollider = transform.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            headCollider.enabled = false;
            enemy.Hit = true;
        }
    }
}