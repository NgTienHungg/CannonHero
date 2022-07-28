using UnityEngine;

public class GUI : MonoBehaviour
{
    [SerializeField] private GameObject UI_Start;
    [SerializeField] private GameObject UI_Play;
    [SerializeField] private GameObject UI_Pause;
    [SerializeField] private GameObject UI_GameOver;
    [SerializeField] private GameObject UI_NewBest;

    private void Start() => OnStart();

    public void OnStart()
    {
        UI_Start.SetActive(true);
        UI_Play.SetActive(false);
        UI_Pause.SetActive(false);
        UI_GameOver.SetActive(false);
        UI_NewBest.SetActive(false);
    }

    public void OnPlay()
    {
        UI_Start.SetActive(false);
        UI_Play.SetActive(true);
    }
    
    public void OnPause()
    {
        UI_Play.SetActive(false);
        UI_Pause.SetActive(true);
    }

    public void OnResume()
    {
        UI_Pause.SetActive(false);
        UI_Play.SetActive(true);
    }

    public void OnReplay()
    {
        OnStart();
        OnPlay();
    }

    public void OnGameOver()
    {
        UI_Play.SetActive(false);
        UI_GameOver.SetActive(true);
    }

    public void OnNewBest()
    {
        UI_Play.SetActive(false);
        UI_NewBest.SetActive(true);
    }
}