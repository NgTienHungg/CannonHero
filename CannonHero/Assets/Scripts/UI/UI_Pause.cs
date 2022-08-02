using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject musicButton;
    [SerializeField] private GameObject soundButton;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject homeButton;
    [SerializeField] private GameObject replayButton;

    private void OnEnable()
    {
        title.transform.localScale = Vector3.zero;
        LeanTween.scale(title, Vector3.one * 1.1f, 0.6f).setEaseOutQuart().setIgnoreTimeScale(true).setOnComplete(OnUIComplete);

        LeanTween.moveLocal(musicButton, new Vector3(-430f, -940f), 0.3f).setEaseOutBack().setDelay(0f).setIgnoreTimeScale(true);
        LeanTween.moveLocal(soundButton, new Vector3(-230f, -940f), 0.25f).setEaseOutBack().setDelay(0.05f).setIgnoreTimeScale(true);
        LeanTween.moveLocal(resumeButton, new Vector3(0f, -940f), 0.2f).setEaseOutBack().setDelay(0.1f).setIgnoreTimeScale(true);
        LeanTween.moveLocal(homeButton, new Vector3(230f, -940f), 0.25f).setEaseOutBack().setDelay(0.05f).setIgnoreTimeScale(true);
        LeanTween.moveLocal(replayButton, new Vector3(430f, -940f), 0.3f).setEaseOutBack().setDelay(0f).setIgnoreTimeScale(true);
    }

    private void OnUIComplete()
    {
        //LeanTween.scale(title, Vector3.one * 1.2f, 1f).setEaseOutCubic().setLoopPingPong();
        //LeanTween.scale(resumeButton, Vector3.one * 1.2f, 0.8f).setEaseOutCubic().setLoopPingPong().setIgnoreTimeScale(true);
    }

    public void Disable()
    {
        LeanTween.scale(title, Vector3.zero, 0f).setIgnoreTimeScale(true);

        LeanTween.moveLocal(musicButton, new Vector3(-430f, -1300f), 0.2f).setEaseInBack().setDelay(0.1f).setIgnoreTimeScale(true);
        LeanTween.moveLocal(soundButton, new Vector3(-230f, -1300f), 0.25f).setEaseInBack().setDelay(0.05f).setIgnoreTimeScale(true);
        LeanTween.moveLocal(resumeButton, new Vector3(0f, -1300f), 0.3f).setEaseInBack().setIgnoreTimeScale(true).setOnComplete(OnCompleteDisable);
        LeanTween.moveLocal(homeButton, new Vector3(230f, -1300f), 0.25f).setEaseInBack().setDelay(0.05f).setIgnoreTimeScale(true);
        LeanTween.moveLocal(replayButton, new Vector3(430f, -1300f), 0.2f).setEaseInBack().setDelay(0.1f).setIgnoreTimeScale(true);
    }

    private void OnCompleteDisable()
    {
        gameObject.SetActive(false);
    }
}
