using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restarter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LevelManager.instance.ResetLevel();
        }
    }
}
