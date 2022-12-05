using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooledObject
{
    void OnObjectSpawn();
    void OnFireball();
    void CosmicSpawn(int seed);
}
