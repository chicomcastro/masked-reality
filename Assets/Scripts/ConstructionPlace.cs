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
        if (haveBuilded && inConstruction == null) {
            haveBuilded = false;
        }

        if (!isPreviewing && inConstruction == null && !haveBuilded)
        {
            inConstruction = WayCrafter.ShowPreview(transform.position);
            isPreviewing = true;
        }

        if (isPreviewing && !haveBuilded && Input.GetMouseButtonDown(0))
        {
            print("Construindo novo bloco!");
            WayCrafter.BuildBlock(transform.position);
            haveBuilded = true;
        }
    }

    public virtual void OnMouseExit()
    {
        PerformExitActions();
    }

    public void PerformExitActions() {

        Destroy(inConstruction);
        inConstruction = null;
        if (!haveBuilded)
            isPreviewing = false;
    }

    private void OnDisable()
    {
        PerformExitActions();
    }
}
