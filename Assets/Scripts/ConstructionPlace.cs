using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionPlace : MonoBehaviour
{
    private bool isPreviewing = false;
    private bool haveBuilded = false;
    private GameObject inConstruction = null;

    public virtual void OnMouseOver()
    {
        if (haveBuilded && inConstruction == null)
        {
            haveBuilded = false;
            isPreviewing = false;
        }

        if (!isPreviewing && inConstruction == null && !haveBuilded)
        {
            inConstruction = WayCrafter.ShowPreview(transform.position);
            isPreviewing = true;
        }

        if (isPreviewing && !haveBuilded && Input.GetMouseButtonDown(0))
        {
            print("Construindo novo bloco!");
            Destroy(inConstruction);
            inConstruction = WayCrafter.BuildBlock(transform.position);
            haveBuilded = true;
        }
    }

    public virtual void OnMouseExit()
    {
        PerformExitActions();
    }

    public void PerformExitActions()
    {
        if (!haveBuilded)
        {
            isPreviewing = false;
            Destroy(inConstruction);
            inConstruction = null;
        }
    }

    private void OnDisable()
    {
        PerformExitActions();
    }
}
