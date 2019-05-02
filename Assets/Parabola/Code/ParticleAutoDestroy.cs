using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroy : MonoBehaviour
{

    public ParticleSystem ps;
    bool played;

    void Start()
    {
        if (ps == null) ps = gameObject.GetComponent<ParticleSystem>();
        if (ps == null) Debug.LogError(gameObject.name + " - No particle system found.");
    }

    void LateUpdate()
    {
        if (!played && ps.isPlaying) played = true;
        if (played && !ps.IsAlive()) Destroy(gameObject);
    }
}
