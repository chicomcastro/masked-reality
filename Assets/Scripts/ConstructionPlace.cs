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
        if (!isPreviewing && inConstruction == null && !haveBuilded)
        {
            inConstruction = WayCrafter.ShowPreview(transform.position);
            isPreviewing = true;
        }

        if (isPreviewing && !haveBuilded && Input.GetMouseButtonDown(0))
        {
            print("Construa!");
            WayCrafter.BuildBlock(transform.position);
            haveBuilded = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            PerformExitActions();
            Destroy(this.gameObject);
        }
    }

    public virtual void OnMouseExit()
    {
        PerformExitActions();
    }

    private void PerformExitActions() {

        Destroy(inConstruction);
        inConstruction = null;
        if (!haveBuilded)
            isPreviewing = false;
    }
}
