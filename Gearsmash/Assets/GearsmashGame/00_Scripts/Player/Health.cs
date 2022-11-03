using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float life;

    public void TakeDamage(float damage)
    {
        life -= damage;
    }
}
