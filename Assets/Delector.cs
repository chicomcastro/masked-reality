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
            GameObject gamo = Instantiate(this.gameObject, transform.position, transform.rotation, transform.parent);
            gamo.GetComponent<Collider>().enabled = false;
            gamo.GetComponent<Renderer>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}
