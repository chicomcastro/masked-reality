using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionPlace : MonoBehaviour
{
    private bool isPreviewing = false;
    private GameObject inConstruction = null;

    private void OnMouseOver()
    {
        if (!isPreviewing && inConstruction == null)
        {
            inConstruction = WayCrafter.ShowPreview(transform.position);
            isPreviewing = true;
        }
    }

    private void OnMouseExit()
    {
        Destroy(inConstruction);
        inConstruction = null;
        isPreviewing = false;
    }
}
