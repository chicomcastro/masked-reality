using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public Text blocksCountText;

    private void Awake()
    {
        instance = this;
    }

    public void SetBlockText(int newBlockQuant) {
        blocksCountText.text = newBlockQuant != 0 ? (newBlockQuant).ToString() : "NOTHING!";
    }
}
