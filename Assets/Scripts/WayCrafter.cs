using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayCrafter : MonoBehaviour
{
    public Camera camera;
    public GameObject blockPrefab;
    public float previewOpacity = 0.25f;
    private GameObject currentPreview;
    private static Stack<GameObject> buildedBlocks = new Stack<GameObject>();

    public static WayCrafter instance;

    private void Awake()
    {
        instance = this;
    }

    void ShowPreview()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            // Do something with the object that was hit by the raycast.
            GameObject gamo = Instantiate(blockPrefab, hit.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public static GameObject ShowPreview(Vector3 fundation)
    {
        GameObject gamo = Instantiate(instance.blockPrefab, fundation + new Vector3(0, 1, 0), Quaternion.identity);
        gamo.GetComponent<Renderer>().material.ChangeAlpha(instance.previewOpacity);
        return gamo;
    }

    public static GameObject BuildBlock(Vector3 fundation)
    {
        GameObject gamo = Instantiate(instance.blockPrefab, fundation + new Vector3(0, 1, 0), Quaternion.identity, LevelManager.instance.GetCurrentLevelObject());
        gamo.GetComponent<Collider>().enabled = true;
        gamo.AddComponent<Delector>();
        buildedBlocks.Push(gamo);
        return gamo;
    }

    public static void ClearLevelBuildedBlocks() {
        foreach (GameObject gamo in buildedBlocks)
        {
            Destroy(gamo);
        }
        buildedBlocks.Clear();
    }
}

public static class Materialxtensions
{
    public static void ChangeAlpha(this Material mat, float alphaValue)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
        mat.SetColor("_Color", newColor);
    }
}
