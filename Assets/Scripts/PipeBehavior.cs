using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBehavior : MonoBehaviour
{
    [SerializeField] private GameObject start;

    [SerializeField] private GameObject end;

    [SerializeField] private GameObject player;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.pipeEnter)
        {
            pipeStart();
        }
    }

    void pipeStart()
    {
        // Call method in player that removes controls
        // 
    }

    void pipeEnd()
    {
        
    }

}
