using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyWater : MonoBehaviour
{
    private bool _flip = false; 

    [SerializeField] private Collider2D col;
    [SerializeField] private float shrinkSpeed = .01f;

    private IEnumerator coroutine;


    // Update is called once per frame
    void Update()
    {
        if(col.enabled == false && _flip == false) {
            coroutine = ShrinkWater(0.1f);
            StartCoroutine(coroutine);
            print("Coroutine started");
        }
    }

    private IEnumerator ShrinkWater(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.localScale = transform.localScale * 0.9f;
        print("Coroutine ended: " + Time.time + " seconds");
    }
}
