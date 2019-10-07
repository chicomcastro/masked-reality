using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private int blocksCount = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddBlock()
    {
        blocksCount += 1;
        CanvasManager.instance.SetBlockText(blocksCount);
    }

    public void UseBlock()
    {
        if (blocksCount <= 0)
        {
            blocksCount = 0;
            return;
        }
        blocksCount -= 1;
        CanvasManager.instance.SetBlockText(blocksCount);
    }

    public bool HaveBlock()
    {
        return blocksCount > 0;
    }

    public void ResetBlockCount()
    {
        blocksCount = 0;
        CanvasManager.instance.SetBlockText(0);
    }

    [ContextMenu("Set debug mode")]
    public void SetDebugMode()
    {
        blocksCount = int.MaxValue;
        CanvasManager.instance.SetBlockText(blocksCount);
    }

    public int GetBlockCount() {
        return blocksCount;
    }
}
