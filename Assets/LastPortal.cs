using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AnimationManager.instance.PlayEndAnimation();
    }
}
