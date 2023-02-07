using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWater : MonoBehaviour
{
    private bool flip = false; 

    [SerializeField] private Collider2D col;

    private float shrinkSpeed = .01f;

    private IEnumerator coroutine;


    // Update is called once per frame
    void Update()
    {
        if(col.enabled == false && flip == false) {

            coroutine = ShrinkWater(0.1f);
            StartCoroutine(coroutine);

            print("Coroutine started");

         
   
        }
/*        if(transform.localScale.x < 0.1f)
        {
            Destroy(gameObject);
        }*/
        
    }


    

    private IEnumerator ShrinkWater(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //transform.localScale -= new Vector3(transform.localScale.x - shrinkSpeed * Time.deltaTime, transform.localScale.y - shrinkSpeed * Time.deltaTime, transform.localScale.z);
        transform.localScale = transform.localScale * 0.9f;
        print("Coroutine ended: " + Time.time + " seconds");
    }


}
