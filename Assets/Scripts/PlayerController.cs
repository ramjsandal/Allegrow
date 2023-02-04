using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Access the transform
        var currentTransform = this.transform;
        
        // Access the position
        Vector2 currentPosition = currentTransform.position;
        
        // Constantly move to the right, and move up and down
        currentTransform.position = new Vector2(currentPosition.x + Time.deltaTime * horizontalSpeed, 
            currentPosition.y + Time.deltaTime * verticalSpeed * Input.GetAxis("Vertical"));
        
        
    }
}
