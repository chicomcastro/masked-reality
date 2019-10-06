using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private void OnEnable()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject player = LifeManager.instance.GetPlayerReference();
        Vector3 startPos = transform.position;
        startPos.y *= 2;
        player.transform.position = startPos;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
