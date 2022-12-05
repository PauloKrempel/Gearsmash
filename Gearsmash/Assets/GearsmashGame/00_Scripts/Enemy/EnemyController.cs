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

        public bool isTutorial;
        [Header("Status")] public EnemyStatus status;
        public float life;
        private Animator anim;
        public bool isAlive = true;

        [Header("WayPoint")]
        public Transform way1;
            
        public Transform way2;
        
        public void Start()
        {
            life = status.Life;
            PlayerManager.Instance.TesteString();
            TargetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
            anim = GetComponent<Animator>();
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

            if (life <= 0 && isAlive )
            {
                anim.SetTrigger("Die");
                isAlive = false;
                //gameObject.SetActive(false);
            }
            
        }

        public void TakeDamage(float damage)
        {
            Debug.LogError("Perdeu vida");
            life -= damage;
            Debug.LogError($"A vida atual do enemy tutorial é de: {life}");
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}

