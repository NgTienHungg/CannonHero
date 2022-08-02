using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private Sprite bg_select;
    [SerializeField] private Sprite bg_buy;
    [SerializeField] private TextMeshProUGUI selectText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Image coinImage;
    private Image bg;

    private void Awake()
    {
        bg = GetComponent<Image>();
    }

    private void Update()
    {
        string code = PlayerPrefs.GetString("CharacterCode");
        int id = PlayerPrefs.GetInt("IdPreview");
        int cost = GameManager.Instance.dataCharacter.list[id].cost;

        // kiem tra xem da so huu Character nay chua
        if (code[id] == '1')
        {
            selectText.gameObject.SetActive(true);
            costText.gameObject.SetActive(false);
            coinImage.gameObject.SetActive(false);

            bg.sprite = bg_select;
        }
        else
        {
            selectText.gameObject.SetActive(false);
            costText.gameObject.SetActive(true);
            coinImage.gameObject.SetActive(true);

            bg.sprite = bg_buy;
            costText.text = cost.ToString();
        }
    }

    public void OnClick()
    {
        string code = PlayerPrefs.GetString("CharacterCode");
        int id = PlayerPrefs.GetInt("IdPreview");
        int cost = GameManager.Instance.dataCharacter.list[id].cost;

        if (code[id] == '1')
        {
            // select
            AudioManager.Instance.PlaySound("TicToc");
            PlayerPrefs.SetInt("IdCharacter", id);
            sceneTransition.LoadScene("Main");
        }
        else
        {
            // buy
            if (PlayerPrefs.GetInt("Coin") >= cost)
            {
                string newCode = "";
                for (int i = 0; i < GameManager.Instance.dataCharacter.list.Count; ++i)
                {
                    if (i == id)
                        newCode += "1";
                    else
                        newCode += code[i];
                }

                AudioManager.Instance.PlaySound("Buy");
                PlayerPrefs.SetString("CharacterCode", newCode);
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - cost);
            } 
        }
    }
}