using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator animator;
    private int nextSceneIndex = -1;
    private string nextSceneName = "";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void LoadScene(int sceneIndex)
    {
        animator.SetTrigger("FadeOut");
        nextSceneIndex = sceneIndex;
    }

    public void LoadScene(string sceneName)
    {
        animator.SetTrigger("FadeOut");
        nextSceneName = sceneName;
    }

    public void OnFadeOutComplete()
    {
        if (nextSceneIndex == -1)
            SceneManager.LoadScene(nextSceneName);
        else
            SceneManager.LoadScene(nextSceneIndex);
    }
}