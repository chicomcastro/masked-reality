using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Vector2[] coordinates;
    public float tableNumber = 5;

    public GameObject cubePrefab;

    void Start()
    {
        foreach (Vector2 c in coordinates)
        {
            for (int i = 0; i < tableNumber; i++)
            {
                for (int j = 0; j < tableNumber; j++)
                {
                    Instantiate(cubePrefab, new Vector3(c.x, 0 ,c.y) + new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
