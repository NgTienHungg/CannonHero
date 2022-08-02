using System;
using System.Collections;
using UnityEngine;

public class WaterGun : Gun
{
    [Header("Water Gun")]
    [SerializeField] private float angleBetweenBullets;
    [SerializeField] private GameObject[] waterBullets;

    public override void Renew()
    {
        base.Renew();
        foreach (var waterBullet in waterBullets)
        {
            waterBullet.transform.position = firePoint.position;
            waterBullet.transform.rotation = Quaternion.identity;
        }
    }

    protected override void NormalFire(float shotAngle)
    {
        waterBullets[1].SetActive(true);
        waterBullets[1].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle - angleBetweenBullets) * fireForce);

        waterBullets[2].SetActive(true);
        waterBullets[2].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle) * fireForce);

        waterBullets[3].SetActive(true);
        waterBullets[3].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle + angleBetweenBullets) * fireForce);

        AudioManager.Instance.PlaySound("WatertShot");
    }

    protected override void SuperFire(float shotAngle)
    {
        waterBullets[0].SetActive(true);
        waterBullets[0].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle - angleBetweenBullets * 2) * fireForce);

        waterBullets[1].SetActive(true);
        waterBullets[1].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle - angleBetweenBullets) * fireForce);

        waterBullets[2].SetActive(true);
        waterBullets[2].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle) * fireForce);

        waterBullets[3].SetActive(true);
        waterBullets[3].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle + angleBetweenBullets) * fireForce);

        waterBullets[4].SetActive(true);
        waterBullets[4].GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle + angleBetweenBullets * 2) * fireForce);

        AudioManager.Instance.PlaySound("WaterShot");
    }

    protected override IEnumerator WaitToRenew()
    {
        while (true)
        {
            if (GamePlay.isVictory || !Array.Find(waterBullets, waterBuller => (waterBuller.activeInHierarchy)))
            {
                Player.isShooting = false;
                Player.hasShot = true;
                break;
            }
            else
                yield return null;
        }

        while (Array.Find(waterBullets, waterBuller => (waterBuller.activeInHierarchy)))
            yield return null;

        if (GamePlay.isPlayerTurn)
        {
            // khi Victory thi isPlayerTurn = false, tranh viec lai der Player.hasShot = true sai logic
            Player.isShooting = false;
            Player.hasShot = true;
        }

        Renew();
    }
}