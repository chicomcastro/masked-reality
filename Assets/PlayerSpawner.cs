using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private void Start() {
        SpawnPlayer();
    }

    private void SpawnPlayer(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 startPos = transform.position;
        startPos.y *= 2;
        player.transform.position = startPos;
    }
}
