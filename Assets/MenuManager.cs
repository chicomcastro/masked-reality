using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(StartDelay());
    }

    public IEnumerator StartDelay()
    {
        yield return new WaitUntil(() => Input.anyKey);
        LifeManager.instance.FreePlayer();
        CanvasManager.instance.DeactiveMenu();
        CanvasManager.instance.StartTutorial();
    }
}
