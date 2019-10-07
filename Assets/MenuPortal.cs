using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        CanvasManager.instance.DeactiveMenu();
        LevelManager.instance.NextLevel();
    }
}
