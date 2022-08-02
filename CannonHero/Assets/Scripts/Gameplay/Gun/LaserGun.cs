using System.Collections;
using UnityEngine;

public class LaserGun : Gun
{
    [Header("Lazer Gun")]
    [SerializeField] private LayerMask layersToHit;
    [SerializeField] private GameObject normalLaser;
    [SerializeField] private GameObject superLaser;
    [SerializeField] private float raycastLength;
    private RaycastHit2D hit;

    public override void Renew()
    {
        base.Renew();
        normalLaser.transform.position = firePoint.position;
        normalLaser.transform.rotation = Quaternion.identity;
        superLaser.transform.position = firePoint.position;
        superLaser.transform.rotation = Quaternion.identity;
    }

    protected override void NormalFire(float shotAngle)
    {
        hit = Physics2D.Raycast(firePoint.position, Utility.CalculateDirection(shotAngle), raycastLength, layersToHit);
        normalLaser.SetActive(true);
        normalLaser.GetComponent<Laser>().Fire();
        AudioManager.Instance.PlaySound("LaserShot");

        if (hit.collider != null)
            StartCoroutine(WaitToWin(normalLaser.GetComponent<Laser>()));
    }

    protected override void SuperFire(float shotAngle)
    {
        hit = Physics2D.Raycast(firePoint.position, Utility.CalculateDirection(shotAngle), raycastLength, layersToHit);
        superLaser.SetActive(true);
        superLaser.GetComponent<Laser>().Fire();
        AudioManager.Instance.PlaySound("SuperLaserShot");

        if (hit.collider != null)
            StartCoroutine(WaitToWin(superLaser.GetComponent<Laser>()));
    }

    protected override IEnumerator WaitToRenew()
    {
        while (normalLaser.activeInHierarchy || superLaser.activeInHierarchy)
            yield return null;

        if (GamePlay.isPlayerTurn)
        {
            Player.isShooting = false;
            Player.hasShot = true;
        }
        
        Renew();
    }

    private IEnumerator WaitToWin(Laser laser)
    {
        float _factor = 3.8f; // do scale cua laser so voi distance
        while (laser.transform.localScale.x / _factor < hit.distance)
            yield return null;

        hit.collider.GetComponentInParent<Enemy>().Dead = true;
        hit.collider.GetComponent<BoxCollider2D>().enabled = false;

        Player.isShooting = false;
        Player.hasShot = true;
    }
}