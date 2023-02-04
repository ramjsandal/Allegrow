using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HorizontalBug : MonoBehaviour
{
    [SerializeField] private GameObject target;

    [SerializeField] private float moveSpeed;

    [SerializeField] float smoothingVal = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime * smoothingVal;
        this.transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
    }
}
