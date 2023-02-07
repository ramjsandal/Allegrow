using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraOnClick : MonoBehaviour
{
    [SerializeField] private GameObject objectToMoveTo;

    [SerializeField] private GameObject MainCam;

    [SerializeField] private GameObject canvas;

    public void click()
    {
        MainCam.transform.position = new Vector3(objectToMoveTo.transform.position.x, objectToMoveTo.transform.position.y, MainCam.transform.position.z);
        
        if(MainCam.transform.position.x == 0 && MainCam.transform.position.y == 0)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        click();
    }
}
