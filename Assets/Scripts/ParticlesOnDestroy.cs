using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ParticlesOnDestroy : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        ParticleSystem effect = Instantiate(particles);
        effect.transform.position = this.transform.position;
        effect.Play();
        
        //Destroy(effect.gameObject, particles.main.duration);
    }
}
