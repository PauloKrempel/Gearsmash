
using System;
using UnityEngine;

public class TestTouch : MonoBehaviour
{
    private InputManager                       inputManager;
    private Camera                             cameraMain;

    private int                                auxDir;
    [SerializeField] private float             speed = 7f;
    [HideInInspector][SerializeField] Animator anim;
    [SerializeField] float                     jumpForce = 300f;
    private Rigidbody2D                        rb2d;
    public LayerMask LayerGround;
    public bool isFlipped = false;
    
    [Header("Combate")]
    public Transform                           attackPoint;
    public float                               attackRange = 0.5f;
    public LayerMask                           enemyLayers;
    public int                                 attackDamage = 40;
    public float                               attackRate = 2f;
    float                                      nextAttack = 0f;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        inputManager.OnEndTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time)
    {
        // Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameraMain.nearClipPlane);
        // Vector3 worldCoordinated = cameraMain.ScreenToWorldPoint(screenCoordinates);
        // worldCoordinated.z = 0;
        // transform.position = worldCoordinated;
    }

    public void TouchHorizontal(int direction)
    {
        auxDir = direction;
    }

    public bool isJumping = false;
    public void TouchJump()
    {
        anim.Play("concept_JumpPlayer");
    }
    public void JumpPlayer()
    {
        if (!isJumping)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            anim.SetTrigger("Jump");
            isJumping = true;
        }
        
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        
        LayerGround = LayerMask.GetMask("Ground");

    }

    private void Update()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;
        if (auxDir != 0)
        {
            transform.Translate(speed * Time.deltaTime * auxDir, 0, 0);
            anim.SetInteger("AnimState", 2);
        }
        else
        {
            anim.SetInteger("AnimState", 0);
        }

        if (auxDir < 0)
        {
            if (!isFlipped)
            {
                transform.localScale = flipped;
                isFlipped = true;
                //transform.Rotate(0f, -180f, 0f);
            }
            //GetComponent<SpriteRenderer>().flipX = true;
            
        }
        else if (auxDir > 0)
        {
            if (isFlipped)
            {
                transform.localScale = flipped;
                isFlipped = false;
                //transform.Rotate(0f, 180f, 0f);
            }
            
            //GetComponent<SpriteRenderer>().flipX = false;
        }
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 2f, LayerGround );
        if (hit != null)
        {
            if (hit.collider.CompareTag("Ground"))
            {
                isJumping = false;
            }
            else
            {
                isJumping = true;
            }
            
        }
        
        
    }

    public void BtnAttack()
    {
        if(Time.time >= nextAttack)
        {
            Attack();
            nextAttack = Time.time + 1f / attackRate;
        }   
    }
    void Attack()
    {
        //Play Animation Attack
        anim.SetTrigger("Attack");
        //Detect Enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    
    private void OnDrawGizmosSelected() {
        if(attackPoint.position == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.down * 2f);
    }
}
