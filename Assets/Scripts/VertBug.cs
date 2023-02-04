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

    private Vector3 _pos;
    private bool _laneSwap;
    
    // Start is called before the first frame update
    private void Start()
    {
        _pos = transform.position;
        _pos.y = laneOne.transform.position.y;
        _laneSwap = true;
        
        InvokeRepeating(nameof(SwapLanes), 0, interval);
    }

    private void SwapLanes()
    {
        _pos.y = _laneSwap ? laneTwo.transform.position.y : laneOne.transform.position.y;
        _laneSwap = !_laneSwap;
    }
}
