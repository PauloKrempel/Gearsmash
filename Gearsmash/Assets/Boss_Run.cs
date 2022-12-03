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
    [SerializeField] private string[] AvailableStatus;
    [SerializeField] private int StateSelect;
    public bool inAnimate = false;

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

        //Debug.Log();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && !inAnimate)
        {
            if (Vector2.Distance(player.position, rb.position) > attackRange)
            {
                Vector3 target = new Vector2(player.position.x, rb.position.y);
                Vector3 newPos = Vector2.MoveTowards(rb.position, target, status.Speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
            }

            if (Vector2.Distance(player.position, rb.position) <= attackRange && !inAnimate)
            {
                RandomState();
            
                if (StateSelect == 1)
                {
                    animator.SetTrigger("Attack");
                    inAnimate = true;
                    //Debug.Log("Estado 01");
                }
                else if (StateSelect == 2)
                {
                    animator.SetTrigger("Jump");
                    inAnimate = true;
                    //Debug.Log("Estado 02");
                }
            }
        }
        

        //inAnimate = true;



        //Debug.Log("indo para" + newPos + "my possition is :" + rb.position);
    }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.ResetTrigger("Attack");
        //animator.SetTrigger("Jump");
        
    }

    private void RandomState()
    {
        if (!inAnimate)
        {
            StateSelect = Random.Range(1, AvailableStatus.Length+1);
            Debug.Log("Sorteando um estado");
            Debug.Log($"O Estado sorteado é: {StateSelect}");
        }
    }
    

}
