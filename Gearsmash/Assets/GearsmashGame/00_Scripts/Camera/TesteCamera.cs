using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystem.Manager;

public class TesteCamera : MonoBehaviour
{
    public CameraShake camShake;
    public float duration;
    public float magnitude;

    public void Sacudir()
    {
       StartCoroutine(camShake.Shake(duration, magnitude));
    }

    public void AtivarCristais()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Sacudir();
        }
    }
}
