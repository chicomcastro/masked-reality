using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;

    public float timeRate = 1f;
    public float inicialDelay = 1.0f;

    private Stack<GameObject> bullets = new Stack<GameObject>();

    private void Start()
    {
        InvokeRepeating("Fire", inicialDelay, 1 / timeRate);
    }

    private void Fire()
    {
        bullets.Push(Instantiate(bullet, bulletSpawn.position, transform.rotation, this.transform));
    }

    private void OnDisable()
    {
        bullets.Clear();
    }
}
