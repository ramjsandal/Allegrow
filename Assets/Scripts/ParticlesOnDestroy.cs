using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnDestroy : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    
    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        ParticleSystem effect = Instantiate(particles);
        effect.transform.position = this.transform.position;
        effect.Play();

        //Destroy(effect.gameObject, particles.main.duration);
    }
}
