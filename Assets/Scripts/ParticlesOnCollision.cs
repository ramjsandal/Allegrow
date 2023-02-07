using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D col)
    { 
      ParticleSystem effect = Instantiate(particles);
      effect.transform.position = this.transform.position;
      effect.Play();
        
      Destroy(effect.gameObject, particles.main.duration);
    }
}
