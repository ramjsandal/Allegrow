using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VertBug : MonoBehaviour
{
    // the two lanes the bug will swap between
    [SerializeField] private GameObject laneOne;
    [SerializeField] private GameObject laneTwo;
    
    // the time between each swap
    [SerializeField] private float interval;

    private float _pos;
    private bool _laneSwap;

    [SerializeField] float smoothingVal;
    
    // Start is called before the first frame update
    private void Start()
    {
        _pos = transform.position.y;
        _laneSwap = true;
        
        InvokeRepeating(nameof(SwapLanes), 0, interval);
    }

    private void SwapLanes()
    {
        _pos = _laneSwap ? laneTwo.transform.position.y : laneOne.transform.position.y;
        _laneSwap = !_laneSwap;
    }

    private void Update()
    {
        float step = Time.deltaTime * smoothingVal;
        Vector3 position = this.transform.position;
        position = Vector2.MoveTowards(position,
            new Vector2(position.x, _pos), step);
        this.transform.position = position;
    }
    
}
