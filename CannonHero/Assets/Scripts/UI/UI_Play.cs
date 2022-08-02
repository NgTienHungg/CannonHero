using UnityEngine;

public class UI_Play : MonoBehaviour
{
    [SerializeField] private GameObject score;

    private void OnEnable()
    {
        score.transform.localScale = Vector3.zero;
        LeanTween.scale(score, Vector3.one, 0.2f).setEaseInBack().setDelay(0.2f);
    }

    public void Disable()
    {
        OnCompleteDisable();
    }

    private void OnCompleteDisable()
    {
        gameObject.SetActive(false);
    }
}