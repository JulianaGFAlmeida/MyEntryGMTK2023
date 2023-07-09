using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameStatusManager gsm;
    [SerializeField]
    private AudioClip collectedSFX;
    private void OnDestroy() {
        gsm.playSFX(collectedSFX);
    }
}
