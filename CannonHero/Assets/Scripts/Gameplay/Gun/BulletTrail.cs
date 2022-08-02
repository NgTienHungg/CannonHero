using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    [SerializeField] private GameObject trailPrefab;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float timeDestroy;
    private float timer;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= timeSpawn)
        {
            GameObject go = Instantiate(trailPrefab, transform.position, transform.rotation);
            Destroy(go, timeDestroy);
        }
    }
}