using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;

    private int currentLevel;
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;

        SetUpGame();
    }

    [ContextMenu("Setup game")]
    public void SetUpGame() {

        currentLevel = 0;
        foreach (GameObject gamo in levels)
        {
            gamo.SetActive(false);
        }

        LoadLevel(currentLevel);
    }

    public void ResetLevel() {
        ReleaseLevel(currentLevel);
        LoadLevel(currentLevel);
    }

    [ContextMenu("Load new level")]
    public void NextLevel()
    {
        ReleaseLevel(currentLevel);
        currentLevel++;
        LoadLevel(currentLevel);
        print("Level is now: " + currentLevel);
    }

    private void LoadLevel(int levelIndex)
    {
        levels[levelIndex].SetActive(true);
    }

    private void ReleaseLevel(int levelIndex)
    {
        levels[levelIndex].SetActive(false);
    }

    public Transform GetCurrentLevel() {
        return levels[currentLevel].transform;
    }
}
