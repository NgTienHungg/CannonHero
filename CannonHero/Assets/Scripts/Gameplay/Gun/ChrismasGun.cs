using System;
using System.Collections;
using UnityEngine;

public class ChrismasGun : Gun
{
    [Header("Chrismas Gun")]
    [SerializeField] private float timeBetweenFirings;
    [SerializeField] private GameObject[] chrismasBullets;
    private bool finish;

    public override void Renew()
    {
        base.Renew();
        finish = false;
        foreach (var chrismasBullet in chrismasBullets)
        {
            chrismasBullet.SetActive(false);
            chrismasBullet.transform.position = firePoint.position;
            chrismasBullet.transform.rotation = Quaternion.identity;
        }
    }

    protected override void NormalFire(float shotAngle)
    {
        chrismasBullets[0].SetActive(true);
        chrismasBullets[0].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle) * fireForce);
        AudioManager.Instance.PlaySound("SantaShot");

        finish = true;
    }

    protected override void SuperFire(float shotAngle)
    {
        StartCoroutine(ContinuousFiring(shotAngle));
    }

    private IEnumerator ContinuousFiring(float shotAngle)
    {
        chrismasBullets[0].SetActive(true);
        chrismasBullets[0].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle) * fireForce);
        AudioManager.Instance.PlaySound("SantaShot");

        yield return new WaitForSeconds(timeBetweenFirings);

        chrismasBullets[1].SetActive(true);
        chrismasBullets[1].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle) * fireForce);
        AudioManager.Instance.PlaySound("SantaShot");

        yield return new WaitForSeconds(timeBetweenFirings);

        chrismasBullets[2].SetActive(true);
        chrismasBullets[2].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle) * fireForce);
        AudioManager.Instance.PlaySound("SantaShot");

        finish = true;
    }

    protected override IEnumerator WaitToRenew()
    {
        while (!finish || Array.Find(chrismasBullets, waterBuller => (waterBuller.activeInHierarchy)))
            yield return null;

        Player.isShooting = false;
        Player.hasShot = true;
        Renew();
    }
}