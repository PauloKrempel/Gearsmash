using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [Header("Player Animation")]
    [HideInInspector][SerializeField] Animator anim;

    [Header("Player Moving")]
    private Rigidbody2D rb2d;
    private float horizontal;
    private float vertical;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 300f;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            anim.Play("concept_JumpPlayer");
            
        }
    }
    public void JumpPlayer()
    {
        rb2d.AddForce(Vector2.up * jumpForce);
    }
    private void FixedUpdate() {
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
    }
}
