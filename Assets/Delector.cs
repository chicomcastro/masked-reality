using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delector : ConstructionPlace
{
    private void OnEnable()
    {
        this.gameObject.GetComponent<Collider>().enabled = true;
        this.gameObject.GetComponent<Renderer>().enabled = true;
    }
    
    public override void OnMouseOver()
    {
        base.OnMouseOver();
        if (Input.GetMouseButtonDown(1))
        {
            PerformExitActions();
            this.gameObject.GetComponent<Collider>().enabled = false;
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
