using UnityEngine;

public class UI_NewBest : MonoBehaviour
{
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject wheel;

    [SerializeField] private GameObject revive;
    [SerializeField] private GameObject payCoinButton;
    [SerializeField] private GameObject watchAdButton;

    [SerializeField] private GameObject homeButton;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject starButton;
    [SerializeField] private GameObject shareButton;

    private void OnEnable()
    {
        title.transform.localScale = Vector3.zero;
        LeanTween.scale(title, Vector3.one, 1f).setEaseOutQuart().setOnComplete(OnCompleteEnable);

        score.transform.localScale = Vector3.zero;
        LeanTween.scale(score, Vector3.one, 1f).setEaseOutQuart();

        LeanTween.rotateAround(wheel, Vector3.forward, 360, 10f).setLoopClamp();

        revive.transform.localScale = Vector3.zero;
        LeanTween.scale(revive, Vector3.one, 0.5f).setEaseOutQuart();

        payCoinButton.transform.localPosition = new Vector3(-1000f, -330f);
        LeanTween.moveLocal(payCoinButton, new Vector3(0f, -330f), 1f).setEaseOutBounce();

        watchAdButton.transform.localPosition = new Vector3(1000f, -560f);
        LeanTween.moveLocal(watchAdButton, new Vector3(0f, -560f), 1f).setEaseOutBounce();

        LeanTween.moveLocal(homeButton, new Vector3(-430f, -940f), 0.3f).setEaseOutBack().setDelay(0f);
        LeanTween.moveLocal(shopButton, new Vector3(-230f, -940f), 0.25f).setEaseOutBack().setDelay(0.05f);
        LeanTween.moveLocal(replayButton, new Vector3(0f, -940f), 0.2f).setEaseOutBack().setDelay(0.1f);
        LeanTween.moveLocal(starButton, new Vector3(230f, -940f), 0.25f).setEaseOutBack().setDelay(0.05f);
        LeanTween.moveLocal(shareButton, new Vector3(430f, -940f), 0.3f).setEaseOutBack().setDelay(0f);
    }

    private void OnCompleteEnable()
    {
        LeanTween.scale(replayButton, Vector3.one * 1.1f, 0.5f).setEaseOutCubic().setLoopPingPong();
        LeanTween.scale(payCoinButton, Vector3.one * 1.1f, 1f).setEaseOutCubic().setLoopPingPong();
        LeanTween.scale(watchAdButton, Vector3.one * 1.1f, 1f).setEaseOutCubic().setLoopPingPong().setDelay(1f);
    }

    public void Disable()
    {
        LeanTween.scale(title, Vector3.zero, 0f);
        LeanTween.scale(score, Vector3.zero, 0f);
        LeanTween.scale(revive, Vector3.zero, 0f);

        LeanTween.moveLocal(payCoinButton, new Vector3(-1000f, -330f), 0.4f).setEaseInOutCirc();
        LeanTween.moveLocal(watchAdButton, new Vector3(1000f, -560f), 0.4f).setEaseInOutCirc();

        LeanTween.moveLocal(homeButton, new Vector3(-430f, -1300f), 0.2f).setEaseInBack().setDelay(0.1f);
        LeanTween.moveLocal(shopButton, new Vector3(-230f, -1300f), 0.25f).setEaseInBack().setDelay(0.05f);
        LeanTween.moveLocal(replayButton, new Vector3(0f, -1300f), 0.3f).setEaseInBack().setOnComplete(OnCompleteDisable);
        LeanTween.moveLocal(starButton, new Vector3(230f, -1300f), 0.25f).setEaseInBack().setDelay(0.05f);
        LeanTween.moveLocal(shareButton, new Vector3(430f, -1300f), 0.2f).setEaseInBack().setDelay(0.1f);
    }

    private void OnCompleteDisable()
    {
        gameObject.SetActive(false);
    }
}