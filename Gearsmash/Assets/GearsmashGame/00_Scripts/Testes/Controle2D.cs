using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Controle2D : MonoBehaviour
{
    [SerializeField] private float forceJump = 200f;
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private Transform pivotDown;

    private float motionSmoothing = .05f;
    private bool airControl = true;
    private bool isGrounded;
    private Rigidbody2D rb2d;
    private bool flipRight = true;
    private float rangeDown = .3f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pivotDown.position, rangeDown, layerGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
    }
}
