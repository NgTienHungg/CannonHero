using UnityEngine;

public class FlyingGround : MonoBehaviour
{
    private Animator animator;

    public void Renew()
    {
        animator.Rebind();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            //AudioManager.Instance.PlaySound("Break");
            animator.SetTrigger("shock");
        }
    }
}