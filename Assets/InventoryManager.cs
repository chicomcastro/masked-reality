﻿using System;
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
    }

    public void UseBlock()
    {
        if (blocksCount <= 0)
        {
            blocksCount = 0;
            return;
        }
        blocksCount -= 1;
    }

    public bool HaveBlock()
    {
        return blocksCount > 0;
    }

    public void ResetBlockCount()
    {
        blocksCount = 0;
    }

    [ContextMenu("Set debug mode")]
    public void SetDebugMode()
    {
        blocksCount = int.MaxValue;
    }
}
