using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelGenerator : MonoBehaviour
{
    public Vector2[] coordinates;
    public float tableNumber = 5;

    public GameObject cubePrefab;

    [ContextMenu("Generate")]
    void GenerateLevel()
    {
        GameObject gamo = new GameObject();
        gamo.name = "newLevel";
        foreach (Vector2 c in coordinates)
        {
            for (int i = 0; i < tableNumber; i++)
            {
                for (int j = 0; j < tableNumber; j++)
                {
                    Instantiate(cubePrefab, new Vector3(c.x, 0, c.y) + new Vector3(i, 0, j), Quaternion.identity, gamo.transform);
                }
            }
        }
    }

    [ContextMenu("Replace Ground(Clone)")]
    void ReplateObj()
    {
        string objName = "Ground(Clone)";
        //You probably want a more specific type than GameObject
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name.Contains(objName) && gameObj.GetComponent<ConstructionPlace>() == null)
            {
                Instantiate(cubePrefab, gameObj.transform.position, Quaternion.identity, gameObj.transform.parent);
                DestroyImmediate(gameObj);
            }
        }
    }
}
