using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXOnDestroy : MonoBehaviour
{

    [SerializeField] private GameObject SFXToPlay;


    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;

        Instantiate(SFXToPlay, transform.position, Quaternion.identity);
    }
}
