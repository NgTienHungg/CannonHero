using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private SceneTransition sceneTransition;

    private void Start()
    {
        AudioManager.Instance.PlaySound("Loading");
        slider.value = 0f;
        progressText.text = "0%";
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        float progress = 0f;
        float maxProgress, targetProgress;

        for (int i = 1; i <= 5; ++i)
        {
            // max progress
            maxProgress = 0.2f * i;

            if (maxProgress == 1f)
                targetProgress = 1f;
            else
                targetProgress = (float)Math.Round(UnityEngine.Random.Range(progress + 0.1f, maxProgress), 2);

            yield return new WaitForSeconds((targetProgress - progress) * 1f); // 1s

            progress = targetProgress;
            slider.value = progress;
            progressText.text = progress * 100 + "%";
        }

        sceneTransition.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}