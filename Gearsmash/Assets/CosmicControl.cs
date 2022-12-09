using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicControl : MonoBehaviour
{
    public static CosmicControl instance;
    public Transform CosmicTransform1;
    public Transform CosmicTransform2;
    public Transform CosmicTransform3;
    private Animator anim;

    public void AttackCosmic()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Cosmic");
        
    }

    private void Awake()
    {
        instance = this;
    }

    public void SpawnCosmic()
    {
        ObjectPooler.Instance.SpawnFromPool("Cosmic", CosmicTransform1.position, Quaternion.identity, 5f, 1);
        //ObjectPooler.Instance.SpawnFromPool("Cosmic", CosmicTransform2.position, Quaternion.identity, 0f, 2);

    }
}
