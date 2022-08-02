using UnityEngine;
using UnityEngine.UI;

public enum NotifyType
{
    Miss,
    Normal,
    HeadShot,
    Crazy,
    UltraKill
}

public class Notify : MonoBehaviour
{
    [Header("Normal")]
    [SerializeField] private Image normalNotify;
    [SerializeField] private Sprite missSpr;
    [SerializeField] private Sprite normalSpr;
    [SerializeField] private Sprite headShotSpr;

    [Header("Crazy")]
    [SerializeField] private Image specialNotify;
    [SerializeField] private Sprite crazySpr;
    [SerializeField] private Sprite ultraKillSpr;

    public void ShowNotify(NotifyType type)
    {
        switch (type)
        {
            case NotifyType.Miss:
                normalNotify.sprite = missSpr;
                break;
            case NotifyType.Normal:
                normalNotify.sprite = normalSpr;
                break;
            case NotifyType.HeadShot:
                normalNotify.sprite = headShotSpr;
                break;
            default:
                Debug.LogWarning("This notify type is invalid in this method! Check again and change method!");
                return;
        }

        normalNotify.enabled = true;
        normalNotify.GetComponent<Animator>().SetTrigger("enable");
    }

    public void ShowSpecicalNotify(NotifyType type)
    {
        switch (type)
        {
            case NotifyType.Crazy:
                specialNotify.sprite = crazySpr;
                break;
            case NotifyType.UltraKill:
                specialNotify.sprite = ultraKillSpr;
                break;
            default:
                Debug.LogWarning("This notify type is invalid in this method! Check again and change method!");
                return;
        }

        specialNotify.enabled = true;
        specialNotify.GetComponent<Animator>().SetTrigger("enable");
    }
}