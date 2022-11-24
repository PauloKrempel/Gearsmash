using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem.Controllers
{
    using Status;
    public class EnemyController : MonoBehaviour
    {
        public float Radius = 10f;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}

