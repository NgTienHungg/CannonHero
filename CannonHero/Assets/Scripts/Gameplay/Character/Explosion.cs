using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject[] objs;
    [SerializeField] private float timeToDisable;
    [SerializeField] private Vector2 rangeX;
    [SerializeField] private Vector2 rangeY;
    private Vector3[] positions;
    private SpriteRenderer[] sprites;
    private Rigidbody2D[] rigids;
    private bool explode;

    public void Renew()
    {
        explode = false;
        for (int i = 0; i < objs.Length; ++i)
        {
            objs[i].transform.localPosition = positions[i];
            objs[i].transform.rotation = Quaternion.identity;
            sprites[i].color = Color.white;

            rigids[i].velocity = Vector3.zero;
            rigids[i].gravityScale = 0f;
            rigids[i].mass = 0f;
        }
    }

    private void Awake()
    {
        positions = new Vector3[objs.Length];
        sprites = new SpriteRenderer[objs.Length];
        rigids = new Rigidbody2D[objs.Length];

        for (int i = 0; i < objs.Length; ++i)
        {
            positions[i] = objs[i].transform.localPosition;
            sprites[i] = objs[i].GetComponent<SpriteRenderer>();
            rigids[i] = objs[i].GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        if (explode)
        {
            for (int i = 0; i < objs.Length; ++i)
            {
                objs[i].transform.Rotate(0f, 0f, Random.Range(90f, 120f) * Time.deltaTime);
            }
        }
    }

    public IEnumerator Explode()
    {
        AudioManager.Instance.PlaySound("Explode");
        explode = true;
        for (int i = 0; i < objs.Length; ++i)
        {
            sprites[i].color = Color.black;

            rigids[i].gravityScale = 1;
            rigids[i].mass = 1;
            rigids[i].AddForce(new Vector2(Random.Range(rangeX.x, rangeX.y), Random.Range(rangeY.x, rangeY.y)), ForceMode2D.Force);
        }

        yield return new WaitForSeconds(timeToDisable);

        // se co TH: Enemy dang Explode nhung duoc Renew Level
        // => Luc nay Enemy da duoc Renew => Color = White && khong tat gameObject nua
        if (sprites[0].color == Color.black)
        {
            Renew();
            gameObject.SetActive(false);
        }
    }
}