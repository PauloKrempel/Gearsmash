using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Jump : StateMachineBehaviour
{
    //public CameraShake camShake;
    public TesteCamera cameraShake;

    //public GameObject Cristal;
    //public Transform spawnUm;
    
    //public float duration;
    //public float magnitude;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cameraShake = animator.GetComponent<TesteCamera>();
        Debug.Log(cameraShake.name);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cameraShake.AtivarCristais();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cameraShake.Sacudir();
    }
}
