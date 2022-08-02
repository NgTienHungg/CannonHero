using UnityEngine;

public class ShopPreview : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;

    private void Update()
    {
        int id = PlayerPrefs.GetInt("IdPreview");
        for (int i = 0; i < characters.Length; ++i)
        {
            if (i == id)
                characters[i].SetActive(true);
            else
                characters[i].SetActive(false);
        }
    }
}