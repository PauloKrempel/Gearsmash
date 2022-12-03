using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer spr;
    public bool isFlipped = true;
    public Transform sp1;
    public Transform sp2;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;

        if (transform.position.x < player.position.x && isFlipped)
        {
            //spr.flipX = true;
            //Debug.LogError("Virado para Esquerda");
            transform.localScale = flipped;
            //transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
        {
            //spr.flipX = false;
            //Debug.LogError("Virado para direita");

            transform.localScale = flipped;
            //transform.Rotate(0f,180f,0f);
            isFlipped = true;
        }
    }
}
