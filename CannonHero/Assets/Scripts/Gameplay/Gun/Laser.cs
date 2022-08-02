using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float laserLength;
    [SerializeField] private float scaleY;
    [SerializeField] private float speed;
    private bool isShooting;

    private void Update()
    {
        if (isShooting)
        {
            transform.localScale = new Vector3(transform.localScale.x + speed * Time.deltaTime, scaleY, 0f);
            if (transform.localScale.x >= laserLength)
            {
                isShooting = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void Fire()
    {
        isShooting = true;
        transform.localScale = new Vector3(0f, scaleY, 0f);
    }
}