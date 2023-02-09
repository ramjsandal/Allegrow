using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyWater : MonoBehaviour
{
    private bool _flip = false; 

    [SerializeField] private Collider2D col;

    private IEnumerator coroutine;


    // Update is called once per frame
    void Update()
    {
        if(col.enabled == false && _flip == false) {
            coroutine = ShrinkWater(0.1f);
            StartCoroutine(coroutine);
            print("Coroutine started");
        }
        if(transform.localScale.x < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator ShrinkWater(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.localScale = transform.localScale * 0.9f;
        
    }
}
