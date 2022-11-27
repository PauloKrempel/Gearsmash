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
        public float Radius = 10f;
        private Transform TargetPlayer;

        public void Start()
        {
            TargetPlayer = PlayerManager.Instance.PlayerPosition.transform;
        }

        private void Update()
        {
            float _distance = Vector3.Distance(TargetPlayer.position, transform.position);
            while (_distance <= Radius)
            {
                
            }
            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}

