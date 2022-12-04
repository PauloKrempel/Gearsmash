using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystem.Manager;

namespace EnemySystem.Controllers
{
    using Status;
    public class EnemyController : MonoBehaviour
    {
        public float Radius = 16f; //for Chase
        public float RadiusToAttack = 12f; //for attack
        public Transform TargetPlayer;
        public bool PlayerInRange = false;
        public float _distancePlayer;
        public bool AtttackPlayer = false;

        [Header("WayPoint")]
        public Transform way1;
            
        public Transform way2;
        
        public void Start()
        {
            PlayerManager.Instance.TesteString();
            TargetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            _distancePlayer = Vector3.Distance(TargetPlayer.position, transform.position);
            if (_distancePlayer <= Radius && _distancePlayer < RadiusToAttack)
            {
                PlayerInRange = true;
            }
            else
            {
                PlayerInRange = false;
            }

            if (_distancePlayer <= RadiusToAttack)
            {
                AtttackPlayer = true;
            }
            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}

