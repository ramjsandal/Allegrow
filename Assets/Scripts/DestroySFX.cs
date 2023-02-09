using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySFX : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;

    void Update()
    {
        if (!_audioSource.isPlaying)
        {
            Destroy(gameObject);

        }


    }
}
