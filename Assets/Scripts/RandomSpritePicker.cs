using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpritePicker : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite[] sprites;


    void Start()
    {

        if(sprites.Length != 0)
        {
            _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }

    }



}
