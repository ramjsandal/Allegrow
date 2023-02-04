using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        throw new NotImplementedException();
    }
}
