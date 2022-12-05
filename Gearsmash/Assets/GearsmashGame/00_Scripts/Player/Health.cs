using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float life;
    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
    }

    IEnumerator Damage()
    {
        spr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spr.color = Color.white;
    }
}
