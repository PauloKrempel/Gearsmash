using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class er_playermoviment : MonoBehaviour
{
    public float speed;
    public float JumpPower;
    public Rigidbody2D rgbd;
    public Animator anime;
    protected Vector2 direction;
    public bool isAction;
    public Vector2 _direction {
        get { return direction; }
        set { direction = value; }
    }

    protected void Start() {
        rgbd = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    protected void FixedUpdate() {
        rgbd.MovePosition(rgbd.position + direction * speed * Time.fixedDeltaTime);
    }

    protected void Update() {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), /*Input.GetAxisRaw("Vertical")*/JumpPower);

        anime.SetFloat("speed", direction.sqrMagnitude);
        isAction = !anime.GetCurrentAnimatorStateInfo(0).IsName("Movement");

        if (direction.sqrMagnitude != 0)
            transform.eulerAngles = direction.x < 0 ? new Vector2(0,180) : new Vector2(0,0);


///////////////////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.S) && !isAction){
            anime.SetTrigger("sword");
            ActionEnable();}

        if (Input.GetKeyDown(KeyCode.A) && !isAction){
            anime.SetTrigger("axe");
            ActionEnable();}
///////////////////////////////////////////////////////////////////////


        if(Input.GetKeyDown(KeyCode.Space)){
            JumpPower = 3;
            anime.SetTrigger("Jumping");
            ActionEnable();
            Invoke("JumpOff", 0.2f);
        }
    }

    void JumpOff(){
        JumpPower = 0f;
    }

    void ActionEnable(){
        isAction = true; 
    }
}
