using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    private Enemy enemy;
    private BoxCollider2D bodyCollider;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        bodyCollider = transform.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            enemy.Dead = true;
            bodyCollider.enabled = false;
        }
    }
}