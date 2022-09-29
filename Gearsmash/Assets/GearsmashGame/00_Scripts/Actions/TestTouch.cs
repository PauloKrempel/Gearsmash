
using System;
using UnityEngine;

public class TestTouch : MonoBehaviour
{
    private InputManager inputManager;
    private Camera cameraMain;

    private int auxDir;
    [SerializeField] private float speed = 7f;
    [HideInInspector][SerializeField] Animator anim;
    [SerializeField] float jumpForce = 300f;
    private Rigidbody2D rb2d;

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

    public void TouchJump()
    {
        anim.Play("concept_JumpPlayer");
    }
    public void JumpPlayer()
    {
        rb2d.AddForce(Vector2.up * jumpForce);
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (auxDir != 0)
        {
            transform.Translate(speed * Time.deltaTime * auxDir, 0, 0);
        }

        if (auxDir < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (auxDir > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
