using System.Collections;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Notify notify;
    private Player player;

    public static int COMBO_CRAZY = 2;

    public static int score, combo;
    public static bool isPlayerTurn, isEnemyTurn;
    public static bool isPlaying, isVictory, isGameOver;
    public static bool isCrazing, isHeadShot;

    public void Renew()
    {
        GamePlay.isPlaying = false;
        GamePlay.isPlayerTurn = false;
        GamePlay.isEnemyTurn = false;
        GamePlay.isVictory = false;
        GamePlay.isGameOver = false;
        GamePlay.isCrazing = false;
        GamePlay.isHeadShot = false;
        GamePlay.score = 0;
        GamePlay.combo = 0;

        player.gameObject.SetActive(true);
        player.Renew();
        levelManager.Renew();
    }

    private void Awake()
    {
        GamePlay.isPlaying = false;
        GamePlay.isPlayerTurn = false;
        GamePlay.isEnemyTurn = false;
        GamePlay.isVictory = false;
        GamePlay.isGameOver = false;
        GamePlay.isCrazing = false;
        GamePlay.isHeadShot = false;
        GamePlay.score = 0;
        GamePlay.combo = 0;

        GameObject playerPrefab = GameManager.Instance.dataCharacter.list[PlayerPrefs.GetInt("IdCharacter")].prefab;
        player = Instantiate(playerPrefab, transform).GetComponent<Player>();

        levelManager.Renew();
    }

    private void Update()
    {
        if (!GamePlay.isPlaying)
            return;

        // TH: Player tu ban chinh minh
        if (!player.gameObject.activeInHierarchy)
        {
            GamePlay.isPlaying = false;
            GamePlay.isGameOver = true;
            return;
        }

        if (GamePlay.isPlayerTurn && Player.hasShot)
        {
            Player.hasShot = false;
            GamePlay.isPlayerTurn = false;
            StartCoroutine(CheckWinLose());
        }
    }

    private IEnumerator CheckWinLose()
    {
        // wait the Enemy complete Update at funtion Explode()
        yield return new WaitForEndOfFrame();

        if (GamePlay.isVictory)
        {
            GamePlay.isVictory = false;

            if (GamePlay.isCrazing)
            {
                AudioManager.Instance.PlaySound("Ultrakill");
                notify.ShowSpecicalNotify(NotifyType.UltraKill);
                GamePlay.isCrazing = false;
                GamePlay.score += 5;
                GamePlay.combo = 0;
                yield return new WaitForSeconds(0.6f);
            }
            else
            {
                if (GamePlay.isHeadShot)
                {
                    notify.ShowNotify(NotifyType.HeadShot);
                    GamePlay.isHeadShot = false;
                    GamePlay.score += 2;
                    GamePlay.combo++;

                    if (combo == GamePlay.COMBO_CRAZY)
                    {
                        AudioManager.Instance.PlaySound("Crazy");
                        GamePlay.isCrazing = true;
                        yield return new WaitForSeconds(0.15f);
                        notify.ShowSpecicalNotify(NotifyType.Crazy);
                        yield return new WaitForSeconds(0.5f);
                    }
                }
                else
                {
                    notify.ShowNotify(NotifyType.Normal);
                    GamePlay.score++;
                    GamePlay.combo = 0;
                }
            }

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
        yield return new WaitForSeconds(0.1f);
        LevelManager.isChangingLevel = true;
    }

    private IEnumerator ChangeTurn()
    {
        GamePlay.isPlayerTurn = false;
        yield return new WaitForSeconds(0.2f);
        GamePlay.isEnemyTurn = true;
    }
}