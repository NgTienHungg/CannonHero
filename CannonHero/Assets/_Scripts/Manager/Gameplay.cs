using System.Collections;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Player player;
    [SerializeField] private Notify notify;

    public static int COMBO_CRAZY = 1;

    public static int score, combo;
    public static bool isPlayerTurn, isEnemyTurn;
    public static bool isPlaying, isVictory, isGameOver;
    public static bool isCrazing, isHeadShot;

    public void Renew()
    {
        Gameplay.isPlaying = false;
        Gameplay.isPlayerTurn = false;
        Gameplay.isEnemyTurn = false;
        Gameplay.isVictory = false;
        Gameplay.isGameOver = false;
        Gameplay.isCrazing = false;
        Gameplay.score = 0;
        Gameplay.combo = 0;

        player.gameObject.SetActive(true);
        player.Renew();
        levelManager.GetCurrentLevel().Renew();
        LevelManager.isChangingLevel = false;
    }

    private void Start() => Renew();

    private void Update()
    {
        if (Gameplay.isPlayerTurn && Player.hasShot)
        {
            Player.hasShot = false;
            StartCoroutine(CheckWinLose());
        }
    }

    private IEnumerator CheckWinLose()
    {
        // wait the Enemy complete Update at funtion Explode()
        yield return new WaitForEndOfFrame();

        if (Gameplay.isVictory)
        {
            if (Gameplay.isCrazing)
            {
                notify.ShowSpecicalNotify(NotifyType.UltraKill);
                Gameplay.isCrazing = false;
                Gameplay.score += 5;
                Gameplay.combo = 0;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                if (Gameplay.isHeadShot)
                {
                    notify.ShowNotify(NotifyType.HeadShot);
                    Gameplay.isHeadShot = false;
                    Gameplay.score += 2;
                    Gameplay.combo++;

                    if (combo == Gameplay.COMBO_CRAZY)
                    {
                        Gameplay.isCrazing = true;
                        notify.ShowSpecicalNotify(NotifyType.Crazy);
                        yield return new WaitForSeconds(1f);
                    }
                }
                else
                {
                    notify.ShowNotify(NotifyType.Normal);
                    Gameplay.score++;
                    Gameplay.combo = 0;
                }
            }

            Gameplay.isVictory = false;
            StartCoroutine(ChangeLevel());
        }
        else
        {
            notify.ShowNotify(NotifyType.Miss);
            StartCoroutine(ChangeTurn());
        }
    }

    private IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(0.05f);
        levelManager.ChangeLevel();
    }

    private IEnumerator ChangeTurn()
    {
        Gameplay.isPlayerTurn = false;
        yield return new WaitForSeconds(0.3f);
        Gameplay.isEnemyTurn = true;
    }
}