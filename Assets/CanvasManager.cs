using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public Text blocksCountText;
    public Text titleText;
    public Text levelText;
    public GameObject inventoryPanel;
    public GameObject pressButtonText;
    public GameObject tutorialText;
    public GameObject restartButton;
    public Animator canvasAnim;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventoryPanel.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);print(restartButton.activeInHierarchy);
    }

    public void SetBlockText(int newBlockQuant)
    {
        int result = 0;
        int.TryParse(blocksCountText.text, out result);
        blocksCountText.text = newBlockQuant != 0 ? (newBlockQuant).ToString() : "NOTHING!";

        // if (!LifeManager.instance.PlayerIsFree())
        //     return;

        // if (newBlockQuant > result)
        //     canvasAnim.Play("IncreaseBlock");
        // else
        //     canvasAnim.Play("DecreaseBlock");
    }

    public void PlayIncreaseBlockAnimation()
    {
        canvasAnim.Play("IncreaseBlock");
    }

    public void PlayDecreaseBlockAnimation()
    {
        canvasAnim.Play("DecreaseBlock");
    }

    public void DeactiveMenu()
    {
        inventoryPanel.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
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

    public void PlayEndAnimation()
    {
        restartButton.gameObject.SetActive(false);
        LifeManager.instance.BlockPlayer();
        canvasAnim.Play("EndAnimation");
    }

    public void UpdateLevelText(int levelIndex){
        levelText.text = levelIndex == 0 ? "TUTORIAL" : "Level " + (levelIndex).ToString();
    }
}
