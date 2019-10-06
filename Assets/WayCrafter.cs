using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayCrafter : MonoBehaviour
{
    public Camera camera;
    public GameObject blockPrefab;
    private GameObject currentPreview;

    public static WayCrafter instance;

    private void Awake() {
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
        return Instantiate(instance.blockPrefab, fundation + new Vector3(0, 1, 0), Quaternion.identity);
    }
}
