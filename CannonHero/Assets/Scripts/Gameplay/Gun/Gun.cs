using System.Collections;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [Header("Gun")]
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float fireForce;
    [SerializeField] protected float aimingSpeed;

    public virtual void Renew()
    {
        transform.rotation = Quaternion.identity;
    }

    public virtual void Aiming()
    {
        transform.Rotate(0f, 0f, aimingSpeed * Time.deltaTime);
        float angle = Mathf.Clamp(transform.eulerAngles.z, 0f, 90f);
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    public virtual void Fire()
    {
        float shotAngle = transform.eulerAngles.z;
        //Debug.Log("Shot angle: " + shotAngle);

        if (GamePlay.isCrazing)
            SuperFire(shotAngle);
        else
            NormalFire(shotAngle);

        // reset Gun after shooting is done
        StartCoroutine(WaitToRenew());
    }

    protected abstract void NormalFire(float shotAngle);

    protected abstract void SuperFire(float shotAngle);

    protected abstract IEnumerator WaitToRenew();
}