using System.Collections;
using UnityEngine;

public class CannonGun : Gun
{
    [Header("Cannon Gun")]
    [SerializeField] private GameObject cannonBullet;

    public override void Renew()
    {
        base.Renew();
        cannonBullet.transform.position = firePoint.position;
        cannonBullet.transform.rotation = Quaternion.identity;
    }

    public override void Aiming()
    {
        transform.Rotate(0f, 0f, aimingSpeed * Time.deltaTime);
    }

    protected override void NormalFire(float shotAngle)
    {
        cannonBullet.SetActive(true);
        cannonBullet.GetComponent<Rigidbody2D>().AddForce(-Utility.CalculateDirection(shotAngle) * fireForce);
        AudioManager.Instance.PlaySound("CannonShot");
    }

    protected override void SuperFire(float shotAngle)
    {
        cannonBullet.SetActive(true);
        cannonBullet.GetComponent<Rigidbody2D>().AddForce(-Utility.CalculateDirection(shotAngle) * fireForce);
        AudioManager.Instance.PlaySound("CannonShot");
    }

    protected override IEnumerator WaitToRenew()
    {
        yield return null;
    }
}