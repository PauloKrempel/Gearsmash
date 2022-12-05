using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CristalSpawn : MonoBehaviour
{
    //public GameObject cristalPrefab;
    public Transform[] spawnCristal;
    private Transform currentSpawn;

    private void FixedUpdate()
    {
        int n = Random.Range(0, spawnCristal.Length);
        for (int i = 0; i < spawnCristal.Length; i++)
        {
            if (n == i)
            {
                currentSpawn = spawnCristal[i];
            }
            ObjectPooler.Instance.SpawnFromPool("cristal", transform.position, Quaternion.identity, 1.5f, 0);
        }
        
    }
    
}
