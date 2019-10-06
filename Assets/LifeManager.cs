using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;

    private GameObject player;

    private void Awake() {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void HidePlayer() {
        player.SetActive(false);
    }

    public void ShowPlayer() {
        player.SetActive(true);
    }

    public GameObject GetPlayerReference() {
        return player;
    }

    public void Die()
    {
        StartCoroutine(DeathSequence());
    }

    private IEnumerator DeathSequence()
    {
        // Play "animatio" (particle system)
        // Desactive player rendering
        player.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        LevelManager.instance.ResetLevel();
    }
}
