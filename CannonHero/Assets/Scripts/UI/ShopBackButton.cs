using UnityEngine;

public class ShopBackButton : MonoBehaviour
{
    [SerializeField] private SceneTransition sceneTransition;

    public void OnClick()
    {
        AudioManager.Instance.PlaySound("Tap");
        sceneTransition.LoadScene("Main");
    }
}