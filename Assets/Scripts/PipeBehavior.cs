using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PipeBehavior : MonoBehaviour
{
    [SerializeField] private int endLane;

    [SerializeField] private GameObject end;

    [SerializeField] private GameObject player;
    private PlayerController _playerController;

    [SerializeField] private float gap = 5f;

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
        pipeEnd();
    }

    void pipeStart()
    {
        // Call method in player that removes controls
        _playerController.enterPipe(end, endLane);
    }

    void pipeEnd()
    {
        // If the player's position is close to the end of the pipe
        // then we call a method in the player
        float playerXPos = player.transform.position.x;
        float endXPos = end.transform.position.x;

        if (playerXPos > (endXPos - gap) && playerXPos < (endXPos + gap))
        {
            _playerController.exitPipe();
        }

    }

}
