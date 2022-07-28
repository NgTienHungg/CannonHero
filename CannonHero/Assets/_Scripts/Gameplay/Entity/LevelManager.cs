using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level generation")]
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private int numberOfLevels;
    [SerializeField] private float levelDistance = 7.3f;
    private List<GameObject> levels = new List<GameObject>();

    [Header("Level transition")]
    [SerializeField] private float levelTransitionSpeed;
    public static bool isChangingLevel = false;

    private void Awake()
    {
        for (int i = 0; i < numberOfLevels; ++i)
        {
            GameObject level = Instantiate(levelPrefab, new Vector3(levelDistance * i, 0f, 0f), Quaternion.identity, transform);
            levels.Add(level);

            // special set up for the first level (with Start UI)
            if (i == 0)
            {
                level.GetComponent<Level>().SpecialSetUp();
                level.gameObject.SetActive(true);
            }
            else
            {
                level.GetComponent<Level>().Renew();
                level.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (isChangingLevel)
        {
            if (levels[0].transform.position.x > 0f)
            {
                // move all level to the left
                foreach (var level in levels)
                    level.transform.Translate(Vector3.left * levelTransitionSpeed * Time.deltaTime);

                // set correct position for all level
                if (levels[0].transform.position.x <= 0f)
                {
                    for (int i = 0; i < numberOfLevels; ++i)
                        levels[i].transform.position = new Vector3(levelDistance * i, levels[0].transform.position.y, 0f);

                    // reset level pass
                    levels[numberOfLevels - 1].GetComponent<Level>().Renew();

                    for (int i = 1; i < numberOfLevels; ++i)
                        levels[i].SetActive(false);

                    // reset new level
                    isChangingLevel = false;
                }
            }
        }
    }

    public void ChangeLevel()
    {
        foreach (var level in levels)
            level.gameObject.SetActive(true);

        // move the last level to the end of list
        GameObject lastLevel = levels[0];
        levels.RemoveAt(0);
        levels.Add(lastLevel);

        isChangingLevel = true;
    }

    public Level GetCurrentLevel()
    {
        foreach (var level in levels)
        {
            if (level.activeInHierarchy)
                return level.GetComponent<Level>();
        }

        return null;
    }
}