using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemySystem.Controllers;

public class DashCol : MonoBehaviour
{
    public float Damage;
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyTutorial"))
        {
            Debug.LogError("Encostou");
            anim.SetTrigger("DashCol");
            other.gameObject.GetComponent<EnemyController>().TakeDamage(Damage);
        }
    }
}
