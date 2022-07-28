using UnityEngine;
using System.Collections;

public class RocketGun : MonoBehaviour
{
    [SerializeField] private GameObject normalBullet;
    [SerializeField] private GameObject superBullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce;

    public void Renew()
    {
        transform.rotation = Quaternion.identity;
        normalBullet.transform.position = firePoint.position;
        normalBullet.transform.rotation = Quaternion.identity;
        superBullet.transform.position = firePoint.position;
        superBullet.transform.rotation = Quaternion.identity;
    }

    public void Fire()
    {
        Debug.Log("Aiming angle: " + transform.eulerAngles.z);
        float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        if (Gameplay.combo == Gameplay.COMBO_CRAZY)
            SuperFire(direction);
        else
            NormalFire(direction);

        // reset Gun after Bullet explode
        StartCoroutine(WaitToRenew());
    }

    private void NormalFire(Vector3 direction)
    {
        normalBullet.SetActive(true);
        normalBullet.GetComponent<Rigidbody2D>().AddForce(direction * fireForce);
    }

    private void SuperFire(Vector3 direction)
    {
        superBullet.SetActive(true);
        superBullet.GetComponent<Rigidbody2D>().AddForce(direction * fireForce);
    }

    private IEnumerator WaitToRenew()
    {
        while (normalBullet.activeInHierarchy || superBullet.activeInHierarchy)
            yield return null;

        Renew();
    }
}