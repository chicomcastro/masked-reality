using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;

    public GameObject player;

    private void Awake()
    {
        instance = this;
        BlockPlayer();
    }

    public void BlockPlayer()
    {
        LifeManager.instance.GetPlayerReference().GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
    }

    public void FreePlayer()
    {
        LifeManager.instance.GetPlayerReference().GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
    }

    public void HidePlayer()
    {
        player.SetActive(false);
    }

    public void ShowPlayer()
    {
        player.SetActive(true);
    }

    public GameObject GetPlayerReference()
    {
        return player;
    }

    public void Die()
    {
        StartCoroutine(DeathSequence());
    }

    private IEnumerator DeathSequence()
    {
        AnimationManager.instance.SpawnHitEffectIn(player.gameObject);
        player.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        LevelManager.instance.ResetLevel();
    }
}
