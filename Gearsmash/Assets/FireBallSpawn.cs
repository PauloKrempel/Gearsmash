using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawn : MonoBehaviour
{
    public Transform pivot;
    public void SpawnFireball()
    {
        ObjectPooler.Instance.SpawnFromPool("Fireball", pivot.position, Quaternion.identity, 2f, 0);
    }


}
