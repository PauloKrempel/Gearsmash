using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class er_moveplayer : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rigid;
    public LayerMask groundLayer;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        float move = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigid.velocity = Vector2.up * jumpForce;
        }
        rigid.velocity = new Vector2(move * moveSpeed, rigid.velocity.y);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

}
