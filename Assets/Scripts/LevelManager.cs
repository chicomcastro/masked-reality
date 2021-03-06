﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;
    public GameObject menu;

    private int currentLevel;
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        menu.SetActive(true);
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
        
        if (levels[levels.Count - 1].GetComponentInChildren<PortalManager>() == null)
        {
            UnityEngine.Debug.LogWarning("Não há PortalManager no último level. Venha aqui ver.");
        }
        else
        {
            levels[levels.Count - 1].GetComponentInChildren<PortalManager>().portalForceNorm = 0f;
            levels[levels.Count - 1].GetComponentInChildren<PortalManager>().gameObject.AddComponent<LastPortal>();
        }

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
        print("Level is now: " + (currentLevel + 1).ToString());
    }

    private void LoadLevel(int levelIndex)
    {
        InventoryManager.instance.ResetBlockCount();
        CanvasManager.instance.UpdateLevelText(levelIndex);
        levels[levelIndex].SetActive(true);
    }

    private void ReleaseLevel(int levelIndex)
    {
        WayCrafter.ClearLevelBuildedBlocks();
        levels[levelIndex].SetActive(false);
    }

    public Transform GetCurrentLevelObject()
    {
        return levels[currentLevel].transform;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
