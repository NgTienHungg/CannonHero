using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private GameObject layer1;
    [SerializeField] private GameObject layer2;
    [SerializeField] private float speed;
    private Vector3 startPosition; // layer 2

    private void Awake()
    {
        startPosition = layer2.transform.position; 
    }

    private void Update()
    {
        if (LevelManager.isChangingLevel)
        {
            layer1.transform.Translate(Vector3.left * speed * Time.deltaTime);
            layer2.transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (layer2.transform.position.x <= 0f)
            {
                layer1.transform.position = Vector3.zero;
                layer2.transform.position = startPosition;
            }
        }
    }
}
