using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelGenerator : MonoBehaviour
{
    public Vector3[] coordinates;
    public float tableNumber = 5;

    public GameObject cubePrefab;
    public float instantiatedAlpha = 1.0f;

    [ContextMenu("Generate")]
    void GenerateLevel()
    {
        GameObject gamo = new GameObject();
        gamo.name = "newLevel";
        foreach (Vector3 c in coordinates)
        {
            for (int i = 0; i < tableNumber; i++)
            {
                for (int j = 0; j < tableNumber; j++)
                {
                    GameObject _ = Instantiate(cubePrefab, c + new Vector3(i, 0, j), Quaternion.identity, gamo.transform);
                    _.GetComponent<Renderer>().enabled = false;
                    _.GetComponent<Collider>().isTrigger = true;
                    DestroyImmediate(_.GetComponent<Delector>());
                    _.AddComponent<ConstructionPlace>();
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
            if (gameObj.name.Contains(objName))
            {
                Instantiate(cubePrefab, gameObj.transform.position, Quaternion.identity, gameObj.transform.parent);
                DestroyImmediate(gameObj);
            }
        }
    }
}
