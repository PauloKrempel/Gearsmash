using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{
    protected er_mov player;

    protected bool JaTomeiDano;
    public int Life = 20;
    public int DamageAttack = 10;
    public int GoldReward = 2;
    void Start()
    {
        JaTomeiDano = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // private void OnTriggerEnter2D(Collision col)
    // {
    //     if(col.gameObject.tag == "playerattack"){
    //         if(player.isAttacking == true && JaTomeiDano == false){
    //             Life = Life - player.PlayerDamage;
    //             
    //         }
    //     }
    // }
}
