using UnityEngine;

public class GameUI : MonoBehaviour
{
    public UI_Start ui_Start;
    public UI_Play ui_Play;
    public UI_Pause ui_Pause;
    public UI_GameOver ui_GameOver;
    public UI_NewBest ui_NewBest;

    private void Start() => OnStart();

    public void OnStart()
    {
        ui_Start.gameObject.SetActive(true);
        ui_Play.gameObject.SetActive(false);
        ui_Pause.gameObject.SetActive(false);
        ui_GameOver.gameObject.SetActive(false);
        ui_NewBest.gameObject.SetActive(false);
    }

    public void OnPlay()
    {
        ui_Start.Disable();
        ui_Play.gameObject.SetActive(true);
    }

    public void OnPause()
    {
        ui_Play.Disable();
        ui_Pause.gameObject.SetActive(true);
    }

    public void OnResume()
    {
        ui_Pause.Disable();
        ui_Play.gameObject.SetActive(true);
    }

    public void OnReplay()
    {
        if (ui_Pause.gameObject.activeInHierarchy)
            ui_Pause.Disable();

        if (ui_GameOver.gameObject.activeInHierarchy)
            ui_GameOver.Disable();

        if (ui_NewBest.gameObject.activeInHierarchy)
            ui_NewBest.Disable();

        ui_Play.gameObject.SetActive(true);
    }

    public void OnGameOver()
    {
        ui_Play.Disable();
        ui_GameOver.gameObject.SetActive(true);
    }

    public void OnNewBest()
    {
        ui_Play.Disable();
        ui_NewBest.gameObject.SetActive(true);
    }

    public void OnRevive()
    {
        if (ui_GameOver.gameObject.activeInHierarchy)
            ui_GameOver.Disable();

        if (ui_NewBest.gameObject.activeInHierarchy)
            ui_NewBest.Disable();

        ui_Play.gameObject.SetActive(true);
    }
}