using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject constructionEffect;
    public static AnimationManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnHitEffectIn(GameObject spawner)
    {
        if (spawner == null)
            return;

        GameObject gamo = Instantiate(hitEffect, spawner.transform.position, spawner.transform.rotation);
        Destroy(gamo, 2.0f);

        if (spawner.GetComponent<Renderer>() == null)
        {
            spawner = spawner.GetComponentInChildren<Renderer>()?.gameObject;
        }

        if (spawner.GetComponent<Renderer>() == null)
        {
            UnityEngine.Debug.LogWarning("There's no renderer to spawn hit effect.");
            return;
        }

        Color _color = spawner.GetComponent<Renderer>().material.color;
        gamo.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", _color);
    }

    public void SpawnConstructionEffectIn(GameObject spawner)
    {
        if (spawner == null)
            return;

        GameObject gamo = Instantiate(constructionEffect, spawner.transform.position, spawner.transform.rotation);
        Destroy(gamo, 2.0f);
    }

    public void PlayEndAnimation() {
        CanvasManager.instance.PlayEndAnimation();
    }
}
