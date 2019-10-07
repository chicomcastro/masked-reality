using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PointToCamera : MonoBehaviour
{
    [ContextMenu("Look at camera")]
    public void LookAtCamera()
    {
        transform.LookAt(Camera.main.transform);
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
