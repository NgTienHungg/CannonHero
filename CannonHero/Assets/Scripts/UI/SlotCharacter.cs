using UnityEngine;
using UnityEngine.UI;

public class SlotCharacter : MonoBehaviour
{
    [SerializeField] private int id;
    private Button button;
    private Image image;

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("IdPreview") == id)
        {
            image.color = Color.white;
            button.interactable = false;
        }
        else
        {
            image.color = Color.gray;
            button.interactable = true;
        }
    }

    public void OnClick()
    {
        AudioManager.Instance.PlaySound("Pop");
        PlayerPrefs.SetInt("IdPreview", id);
    }
}