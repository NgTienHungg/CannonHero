using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GamePlay gamePlay;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private SceneTransition sceneTransition;

    private void Start()
    {
        AudioManager.Instance.PlayMusic("Background");
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (gameUI.ui_Start.gameObject.activeInHierarchy)
        {
            if (Input.GetMouseButtonUp(0) && !Utility.IsPointerOverUIObject())
                OnPlay();
        }

        if (GamePlay.isGameOver)
            OnGameOver();
    }

    private void SetUpMusic()
    {
        AudioManager.Instance.StopAllMusic();
        AudioManager.Instance.PlayMusic("Background");
    }

    private void OnPlay()
    {
        SetUpMusic();
        AudioManager.Instance.PlaySound("Ready");
        gameUI.OnPlay();
        Time.timeScale = 1;
        GamePlay.isPlaying = true;
        GamePlay.isPlayerTurn = true;
    }

    public void OnPause()
    {
        AudioManager.Instance.PlaySound("Tap");
        gameUI.OnPause();
        Time.timeScale = 0;
        GamePlay.isPlaying = false;
    }

    public void OnResume()
    {
        AudioManager.Instance.PlaySound("Tap");
        gameUI.OnResume();
        Time.timeScale = 1;
        GamePlay.isPlaying = true;
    }

    private void OnGameOver()
    {
        GamePlay.isPlaying = false;
        GamePlay.isGameOver = false;

        AudioManager.Instance.StopMusic("Background");
        if (GamePlay.score > PlayerPrefs.GetInt("BestScore"))
        {
            AudioManager.Instance.PlayMusic("NewRecord");
            PlayerPrefs.SetInt("BestScore", GamePlay.score);
            gameUI.OnNewBest();
        }
        else
        {
            AudioManager.Instance.PlayMusic("GameOver");
            gameUI.OnGameOver();
        }
    }

    public void OnReplay()
    {
        AudioManager.Instance.PlaySound("Tap");
        gamePlay.Renew();
        gameUI.OnReplay();
        OnPlay();
    }

    public void OnRevive()
    {
        int saveScore = GamePlay.score;
        int saveCombo = GamePlay.combo;
        bool saveIsCrazing = GamePlay.isCrazing;

        gameUI.OnRevive();
        OnReplay();

        GamePlay.score = saveScore;
        GamePlay.combo = saveCombo;
        GamePlay.isCrazing = saveIsCrazing;
    }

    public void OnHome()
    {
        SetUpMusic();
        AudioManager.Instance.PlaySound("Tap");
        sceneTransition.LoadScene("Main");
    }

    public void OnShop()
    {
        SetUpMusic();
        AudioManager.Instance.PlaySound("Tap");
        sceneTransition.LoadScene("Shop");
    }

    public void OnRating()
    {
        AudioManager.Instance.PlaySound("Tap");
    }

    public void OnRanking()
    {
        AudioManager.Instance.PlaySound("Tap");
    }

    public void OnShare()
    {
        AudioManager.Instance.PlaySound("Tap");
    }

    public void OnPayCoinToRevive()
    {
        AudioManager.Instance.PlaySound("Tap");
        if (PlayerPrefs.GetInt("Coin") >= 50)
        {
            OnRevive();
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 50);
        }
    }

    public void OnWatchAdToRevive()
    {
        AudioManager.Instance.PlaySound("Tap");
        Application.OpenURL("https://github.com/NgTienHungg");
        OnRevive();
    }
}