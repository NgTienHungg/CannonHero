using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float angle = Mathf.Atan2(rigidBody.velocity.y, rigidBody.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("player bullet explode");
        EndOfShot();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level")
        {
            Debug.Log("exit level");
            EndOfShot();
        }
    }

    private void EndOfShot()
    {
        Player.isShooting = false;
        Player.hasShot = true;
        gameObject.SetActive(false);

        Debug.Log("bullet : " + gameObject.activeInHierarchy);
    }
}