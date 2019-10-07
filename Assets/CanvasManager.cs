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
    public GameObject pressButtonText;
    public GameObject tutorialText;
    public Animator canvasAnim;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventoryPanel.gameObject.SetActive(false);
    }

    public void SetBlockText(int newBlockQuant)
    {

        blocksCountText.text = newBlockQuant != 0 ? (newBlockQuant).ToString() : "NOTHING!";

        if (newBlockQuant == 0)
            return;

        int result = 0;
        int.TryParse(blocksCountText.text, out result);
        if (newBlockQuant > result)
            canvasAnim.Play("IncreaseBlock");
        else if (newBlockQuant < result)
            canvasAnim.Play("DecreaseBlock");
    }

    public void DeactiveMenu()
    {
        inventoryPanel.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        pressButtonText.gameObject.SetActive(false);
    }

    public void DeactivateTutorial()
    {
        tutorialText.gameObject.SetActive(false);
    }

    public void StartTutorial()
    {
        canvasAnim.Play("TutorialTip");
    }
}
