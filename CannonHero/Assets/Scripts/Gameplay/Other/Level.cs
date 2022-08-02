using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject flyingGroundPrefab;
    private GameObject enemy, flyingGround;

    [Header("Spawn Range")]
    [SerializeField] private Vector2 horizontalRange;
    [SerializeField] private Vector2 verticalRange;

    private void Awake()
    {
        flyingGround = Instantiate(flyingGroundPrefab, transform);
        enemy = Instantiate(enemyPrefab, transform);
        Renew();
    }

    public void Renew()
    {
        // random flying ground position
        float randX = Random.Range(horizontalRange.x, horizontalRange.y);
        float randY = Random.Range(verticalRange.x, verticalRange.y);
        flyingGround.transform.position = transform.position + new Vector3(randX, randY, 0f);
        flyingGround.GetComponent<FlyingGround>().Renew();

        enemy.SetActive(true);
        enemy.GetComponent<Enemy>().Renew();
        enemy.transform.position = flyingGround.transform.position + new Vector3(0f, 0.49f, 0f);
    }
}