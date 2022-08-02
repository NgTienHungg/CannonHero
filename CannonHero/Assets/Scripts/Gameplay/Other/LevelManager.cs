using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level generation")]
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private int numberOfLevels = 3;
    [SerializeField] private float levelDistance = 7.3f;
    private static List<GameObject> levels;

    [Header("Level transition")]
    [SerializeField] private float levelTransitionSpeed;
    public static bool isChangingLevel;

    public void Renew()
    {
        LevelManager.isChangingLevel = false;
        levels[1].GetComponent<Level>().Renew();
        for (int i = 0; i < numberOfLevels; i++)
        {
            levels[i].transform.position = new Vector3(levelDistance * i - levelDistance, 0f, 0f);
        }
    }

    private void Awake()
    {
        levels = new List<GameObject>();
        for (int i = 0; i < numberOfLevels; ++i)
        {
            GameObject level = Instantiate(levelPrefab, new Vector3(levelDistance * i - levelDistance, 0f, 0f), Quaternion.identity, transform);
            levels.Add(level);
        }
    }

    private void Update()
    {
        if (!GamePlay.isPlaying)
            return;

        if (LevelManager.isChangingLevel)
        {
            if (levels[1].transform.position.x > -levelDistance)
            {
                // move all level to the left
                foreach (var level in levels)
                    level.transform.Translate(Vector3.left * levelTransitionSpeed * Time.deltaTime);

                // set correct position for all level
                if (levels[1].transform.position.x <= -levelDistance)
                {
                    // move the old level to the end of list and renew it
                    GameObject _level = levels[0];
                    _level.GetComponent<Level>().Renew();
                    levels.RemoveAt(0);
                    levels.Add(_level);

                    for (int i = 0; i < numberOfLevels; ++i)
                        levels[i].transform.position = new Vector3(levelDistance * i - levelDistance, 0f, 0f);

                    LevelManager.isChangingLevel = false;
                    GamePlay.isPlayerTurn = true;
                }
            }
        }
    }

    public static GameObject GetCurrentLevel()
    {
        return levels[1];
    }
}