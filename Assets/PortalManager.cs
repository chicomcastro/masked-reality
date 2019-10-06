using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public float portalForceNorm = 25f;
    public float delayForNewLevel = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(FinishAnimation(other.gameObject));
        }
    }

    public IEnumerator FinishAnimation(GameObject player)
    {
        player.GetComponent<Rigidbody>().AddForce(new Vector3(0, portalForceNorm, 0), ForceMode.Impulse);
        yield return new WaitForSeconds(delayForNewLevel);
        LevelManager.instance.NextLevel();
    }
}
