using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystem.Manager;

public class TesteCamera : MonoBehaviour
{
    public CameraShake camShake;
    public float duration;
    public float magnitude;
    
    public GameObject[] Cristal;
    public Transform spawnUm;
    public Transform spawnDois;

    public void Sacudir()
    {
       StartCoroutine(camShake.Shake(duration, magnitude));
    }

    public void AtivarCristais()
    {
        //Cristal.SetActive(true);
        //Instantiate(Cristal, PlayerManager.Instance.PlayerPosition.transform) ;
        // for (int i = 0; i < Cristal.Length; i++)
        // {
        //     float numero = Random.Range(1, 4);
        //     if (numero == 1 || numero == 3)
        //     {
        //         Instantiate(Cristal[i], spawnUm.transform);
        //     }
        //     else if (numero == 2 || numero == 4)
        //     {
        //         Instantiate(Cristal[i], spawnDois.transform);
        //     }
        // }

        foreach (var cristal in Cristal)
        {
            cristal.SetActive(true);
        }
        
    }
    
}
