using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent( (typeof(Rigidbody2D)))]
public class FireBall : MonoBehaviour, IPooledObject
{
    public Rigidbody2D rb2d;
    public Transform playerTransform;
    public Transform pivot;
    public float speed;
    public bool isFlipped = true;

    private Vector3 dirBullet;
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;

        if (transform.position.x < playerTransform.position.x && isFlipped)
        {
            dirBullet = Vector3.left;
            transform.localScale = flipped;
            isFlipped = false;
        }
        else if (transform.position.x > playerTransform.position.x && !isFlipped)
        {
            dirBullet = Vector3.right;
            transform.localScale = flipped;
            isFlipped = true;
        }
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void OnObjectSpawn()
    {
        return;
    }
    public void CosmicSpawn(int seed)
    {
        return;
    }

    public void OnFireball()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        pivot = GameObject.FindGameObjectWithTag("pivot").transform;
        transform.position = pivot.position;
        LookAtPlayer();

        var position = playerTransform.position;
        Vector3 target = new Vector2(position.x, rb2d.position.y);
        rb2d.AddForce(dirBullet * 2500f, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Debug.LogError("Colidiu com o player");
            collision.collider.GetComponent<Health>().TakeDamage(25);
            gameObject.SetActive(false);
        }
    }
}
