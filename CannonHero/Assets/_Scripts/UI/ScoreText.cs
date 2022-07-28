using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private string prefix;
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreText.text = prefix + Gameplay.score.ToString();
    }
}