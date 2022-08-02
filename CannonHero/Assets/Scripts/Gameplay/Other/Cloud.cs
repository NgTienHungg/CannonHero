using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float startX;
    [SerializeField] private float limitX;
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= limitX)
            transform.position = new Vector3(startX, transform.position.y, 0f);
    }
}