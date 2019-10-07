using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CanvasManager.instance.DeactivateTutorial();
        }
    }
}
