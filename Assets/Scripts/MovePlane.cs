using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{

    private Vector2 startPos;

    [SerializeField] private float moveSpeed = 1f;

    private float xBounds = -9.5f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);

        if(transform.position.x <= xBounds)
        {
            transform.position = startPos;
        }
    }
}
