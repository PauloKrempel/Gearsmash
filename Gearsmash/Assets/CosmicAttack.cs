using System;
using System.Collections;
using System.Collections.Generic;
using EnemySystem.Controllers;
using EnemySystem.Status;
using UnityEngine;

public class CosmicAttack : MonoBehaviour, IPooledObject
{
    public float Damage;
    public GameObject Effect;
    public GameObject Cosmic;
    
    public void OnObjectSpawn()
    {
        return;
    }
    public void OnFireball()
    {
        return;
    }

    public void CosmicSpawn(int seed)
    {
        if (seed == 1)
        {
            transform.position = CosmicControl.instance.CosmicTransform1.position;
            ObjectPooler.Instance.SpawnFromPool("Cosmic", CosmicControl.instance.CosmicTransform2.position, Quaternion.identity, 0f, 2);
        }
        else if(seed == 2)
        {
            transform.position = CosmicControl.instance.CosmicTransform2.position;
        }
        Effect.SetActive(true);
    }
    public void DisableSkill()
    {
        gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyTutorial"))
        {
            Debug.LogError("Encostou");
            other.gameObject.GetComponent<EnemyController>().TakeDamage(Damage);
        }
    }
}
