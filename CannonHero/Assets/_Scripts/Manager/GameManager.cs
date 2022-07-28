using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Gameplay gameplay;
    [SerializeField] private GUI gui;

    private void Update()
    {
        if (!Gameplay.isPlaying && !Gameplay.isPlayerTurn && !Gameplay.isEnemyTurn)
        {
            if (Input.GetMouseButtonUp(0) && !Utility.IsPointerOverUIObject())
                OnPlay();
        }

        if (Gameplay.isGameOver)
            OnGameOver();
    }

    private void OnPlay()
    {
        gui.OnPlay();
        Time.timeScale = 1;
        Gameplay.isPlaying = true;
        Gameplay.isPlayerTurn = true;
    }

    public void OnPause()
    {
        gui.OnPause();
        Time.timeScale = 0;
        Gameplay.isPlaying = false;
    }

    public void OnResume()
    {
        gui.OnResume();
        Time.timeScale = 1;
        Gameplay.isPlaying = true;
    }

    public void OnReplay()
    {
        gui.OnStart();
        gui.OnPlay();
        gameplay.Renew();
    }

    public void OnHome()
    {
        SceneManager.LoadScene("Main");
    }

    private void OnGameOver()
    {
        Gameplay.isPlaying = false;
        Gameplay.isGameOver = false;

        if (Gameplay.score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", Gameplay.score);
            gui.OnNewBest();
        }
        else
            gui.OnGameOver();
    }
}