using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "FlyingGround")
            AudioManager.Instance.PlaySound("Break");

        gameObject.SetActive(false);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level")
            gameObject.SetActive(false);
    }
}