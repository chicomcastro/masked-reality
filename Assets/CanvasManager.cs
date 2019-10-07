using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public Text blocksCountText;
    public Text titleText;
    public GameObject inventoryPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventoryPanel.gameObject.SetActive(false);
    }

    public void SetBlockText(int newBlockQuant) {
        blocksCountText.text = newBlockQuant != 0 ? (newBlockQuant).ToString() : "NOTHING!";
    }

    public void DeactiveMenu() {
        inventoryPanel.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
    }
}
