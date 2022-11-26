using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemySystem.Status;

public class Boss_Run : StateMachineBehaviour
{
    public EnemyStatus status; 
    private Transform player;
    private Rigidbody2D rb;
    private Boss boss;

    public float attackRange = 5f;
    
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        
        Vector3 target = new Vector2(player.position.x, rb.position.y);
        Vector3 newPos = Vector2.MoveTowards(rb.position, target, status.Speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
        
        Debug.Log("indo para" + newPos + "my possition is :" + rb.position);
    }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    
}
