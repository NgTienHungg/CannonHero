using UnityEngine;

public class UI_Start : MonoBehaviour
{
    [SerializeField] private GameObject titleGame;
    [SerializeField] private GameObject bestScore;
    [SerializeField] private GameObject musicButton;
    [SerializeField] private GameObject soundButton;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject rankingButton;
    [SerializeField] private GameObject ratingButton;

    private void OnEnable()
    {
        titleGame.transform.localScale = Vector3.zero;
        LeanTween.scale(titleGame, Vector3.one, 1f).setEaseOutElastic().setOnComplete(OnTitleComplete);
        
        bestScore.transform.localScale = Vector3.zero;
        LeanTween.scale(bestScore, Vector3.one, 1f).setEaseOutQuart();

        LeanTween.moveLocal(musicButton, new Vector3(-430f, -940f), 0.5f).setEaseOutBack().setDelay(0.1f);
        LeanTween.moveLocal(soundButton, new Vector3(-230f, -940f), 0.5f).setEaseOutBack().setDelay(0.15f);
        LeanTween.moveLocal(shopButton, new Vector3(0f, -940f), 0.5f).setEaseOutBack().setDelay(0.2f);
        LeanTween.moveLocal(rankingButton, new Vector3(230f, -940f), 0.5f).setEaseOutBack().setDelay(0.15f);
        LeanTween.moveLocal(ratingButton, new Vector3(430f, -940f), 0.5f).setEaseOutBack().setDelay(0.1f);
    }

    private void OnTitleComplete()
    {
        LeanTween.scale(titleGame, Vector3.one * 1.1f, 1.2f).setEaseInOutQuart().setLoopPingPong();
        LeanTween.moveLocal(bestScore, new Vector3(0f, 285f), 1.2f).setEaseInOutBack().setLoopPingPong();
    }

    public void Disable()
    {
        LeanTween.scale(titleGame, Vector3.zero, 0.5f).setEaseInBack().setOnComplete(OnCompleteDisable);
        LeanTween.scale(bestScore, Vector3.zero, 0.5f).setEaseInBack();

        LeanTween.moveLocal(musicButton, new Vector3(-430f, -1300f), 0.3f).setEaseInBack().setDelay(0.1f);
        LeanTween.moveLocal(soundButton, new Vector3(-230f, -1300f), 0.35f).setEaseInBack().setDelay(0.05f);
        LeanTween.moveLocal(shopButton, new Vector3(0f, -1300f), 0.4f).setEaseInBack();
        LeanTween.moveLocal(rankingButton, new Vector3(230f, -1300f), 0.35f).setEaseInBack().setDelay(0.05f);
        LeanTween.moveLocal(ratingButton, new Vector3(430f, -1300f), 0.4f).setEaseInBack().setDelay(0.1f);
    }

    private void OnCompleteDisable()
    {
        gameObject.SetActive(false);
    }
}