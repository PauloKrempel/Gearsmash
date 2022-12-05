using System.Collections;
using System.Collections.Generic;
using EnemySystem.Controllers;
using UnityEngine;
using UnityEngine.AI;
using EnemySystem.Status;


public class Enemy_Patrol : StateMachineBehaviour
{
    public Transform way1;
    public Transform way2;
    [SerializeField] private Transform currentWay;
    private Transform memoryDir;
    private Transform myTransform;
    private Rigidbody2D rb;
    public EnemyStatus status;
    private float _distance;
    private EnemyController _enemyController;
    


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        way1 = animator.GetComponent<EnemyController>().way1;
        way2 = animator.GetComponent<EnemyController>().way2;
        rb = animator.GetComponent<Rigidbody2D>();
        myTransform = animator.GetComponent<Transform>();
        _enemyController = animator.GetComponent<EnemyController>();
        
        currentWay = way1;
        memoryDir = way1;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _distance = Vector3.Distance(currentWay.position, myTransform.transform.position);
        if (_enemyController.PlayerInRange)
        {
            currentWay = _enemyController.TargetPlayer;
            if (_enemyController.AtttackPlayer)
            {
                animator.SetTrigger("Attack");
            }
        }
        else if (!_enemyController.PlayerInRange)
        {
            if (currentWay != way1 || currentWay != way2)
            {
                currentWay = memoryDir;
            }
            
            if (_distance <= 0.999f && currentWay == way1)
            {
                currentWay = way2;
                memoryDir = way2;
                myTransform.Rotate(0f, -180f, 0f);
            }
            else if (_distance <= 0.999f && currentWay == way2)
            {
                currentWay = way1;
                memoryDir = way1;
                myTransform.Rotate(0f, -180f, 0f);
            }
        }
        Vector3 target = new Vector2(currentWay.position.x, rb.position.y);
        Vector3 newPos = Vector2.MoveTowards(rb.position, target, status.Speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
         
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
}
