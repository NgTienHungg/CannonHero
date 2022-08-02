using UnityEngine;
using System.Collections;

public class RocketGun : Gun
{
    [Header("Rocket Gun")]
    [SerializeField] private GameObject normalBullet;
    [SerializeField] private GameObject superBullet;

    public override void Renew()
    {
        base.Renew();
        normalBullet.transform.position = firePoint.position;
        normalBullet.transform.rotation = Quaternion.identity;
        superBullet.transform.position = firePoint.position;
        superBullet.transform.rotation = Quaternion.identity;
    }

    protected override void NormalFire(float shotAngle)
    {
        normalBullet.SetActive(true);
        normalBullet.GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle) * fireForce);
        AudioManager.Instance.PlaySound("RocketShot");
    }

    protected override void SuperFire(float shotAngle)
    {
        superBullet.SetActive(true);
        superBullet.GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle) * fireForce);
        AudioManager.Instance.PlaySound("RocketShot");
    }

    protected override IEnumerator WaitToRenew()
    {
        while (normalBullet.activeInHierarchy || superBullet.activeInHierarchy)
            yield return null;

        Player.isShooting = false;
        Player.hasShot = true;
        Renew();
    }
}