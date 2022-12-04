using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour , IPooledObject
{
    public Boss boss;
    public Transform spawnUm;
    public Transform spawnDOIS;
    public void OnObjectSpawn()
    {
        int n = Random.Range(1, 2);
        if (n == 1)
        {
            transform.position = spawnUm.position;
        }
        else if(n == 2)
        {
            transform.position = spawnDOIS.position;
        }
    }

    public void OnFireball()
    {
        return;
    }
    
    
}
