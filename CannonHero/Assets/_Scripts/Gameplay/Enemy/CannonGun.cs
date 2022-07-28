using UnityEngine;

public class CannonGun : MonoBehaviour
{
    [SerializeField] private GameObject cannonBullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce;

    public void Fire()
    {
        float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        cannonBullet.SetActive(true);
        cannonBullet.GetComponent<Rigidbody2D>().AddForce(-direction * fireForce); //! direction bi nguoc, do goc dang duong, k hieu
    }
}