using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;

    private int currentLevel;
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;

        SetUpGame();
    }

    [ContextMenu("Setup game")]
    public void SetUpGame()
    {
        levels = new List<GameObject>();

        string objName = "Level";
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name.Contains(objName))
            {
                levels.Add(gameObj);
            }
        }

        print("Foram registrados " + levels.Count + " leveis.");
        levels.Sort((x, y) => x.name.CompareTo(y.name));
        levels[levels.Count-1].GetComponentInChildren<PortalManager>().portalForceNorm = 0f;

        currentLevel = 0;
        foreach (GameObject gamo in levels)
        {
            gamo.SetActive(false);
        }

        LoadLevel(currentLevel);
    }

    public void ResetLevel()
    {
        ReleaseLevel(currentLevel);
        LoadLevel(currentLevel);
        LifeManager.instance.ShowPlayer();
    }

    [ContextMenu("Load new level")]
    public void NextLevel()
    {
        if (currentLevel >= levels.Count - 1)
            return;
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
        WayCrafter.ClearLevelBuildedBlocks();
        levels[levelIndex].SetActive(false);
    }

    public Transform GetCurrentLevel()
    {
        return levels[currentLevel].transform;
    }
}
