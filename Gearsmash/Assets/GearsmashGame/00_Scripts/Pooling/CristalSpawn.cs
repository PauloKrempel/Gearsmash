using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalSpawn : MonoBehaviour
{
    //public GameObject cristalPrefab;

    private void FixedUpdate()
    {
        ObjectPooler.Instance.SpawnFromPool("cristal", transform.position, Quaternion.identity);
    }
}
