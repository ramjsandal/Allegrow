using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnClick : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private GameObject darken;
    [SerializeField] private GameObject[] dancingFlowers;

    [Header("Other Stuff")]

    [SerializeField] private GameObject[] otherDarkens;
    [SerializeField] private GameObject[] otherFlowers;




    private void OnMouseDown()
    {
        darken.SetActive(false);
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
        else
        {
            _audioSource.Stop();
            _audioSource.PlayOneShot(_audioClip);
        }

        foreach (GameObject flower in dancingFlowers)
        {
            flower.SetActive(true);
        }


        foreach (GameObject d in otherDarkens)
        {
            d.SetActive(true);
        }

        foreach (GameObject otherFlower in otherFlowers)
        {
            otherFlower.SetActive(false);
        }

        //darken.SetActive(_audioSource.clip == _audioClip && _audioSource.isPlaying);

    }

}
