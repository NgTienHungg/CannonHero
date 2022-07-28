using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private Vector2 horizontalRange;
    [SerializeField] private Vector2 verticalRange;
    private GameObject target;

    public void Renew()
    {
        if (target != null)
            Destroy(target);

        // random target position
        float randX = Random.Range(horizontalRange.x, horizontalRange.y);
        float randY = Random.Range(verticalRange.x, verticalRange.y);
        Vector3 targetPosition = new Vector3(randX, randY, 0f);
        target = Instantiate(targetPrefab, transform.position + targetPosition, Quaternion.identity, transform);
    }

    public void SpecialSetUp()
    {
        float randX = Random.Range(1.8f, 2.2f);
        float randY = Random.Range(-1.2f, -1.8f);
        Vector3 targetPosition = new Vector3(randX, randY, 0f);
        target = Instantiate(targetPrefab, transform.position + targetPosition, Quaternion.identity, transform);
    }
}