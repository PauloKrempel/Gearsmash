using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteCamera : MonoBehaviour
{
    public CameraShake camShake;

    public void Sacudir()
    {
       StartCoroutine(camShake.Shake(.45f, .235f));
    }
    
}
