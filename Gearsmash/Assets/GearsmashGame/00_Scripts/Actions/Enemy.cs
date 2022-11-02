using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    [SerializeField] int currentHealth;
    private void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die(){
        Debug.Log("Enemy Die");
        // Die Animation
        animator.SetBool("IsDead", true);
        
    }

    public void isDead()
    {
        //Disable the Enemy
        GetComponent<Collider2D>().isTrigger = true;
        //this.enabled = false;
    }
}
