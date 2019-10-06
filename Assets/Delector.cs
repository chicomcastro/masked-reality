using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delector : ConstructionPlace
{
    public override void OnMouseOver()
    {
        base.OnMouseOver();
        if (Input.GetMouseButtonDown(1))
        {
            PerformExitActions();
            Destroy(this.gameObject);
        }
    }
}
