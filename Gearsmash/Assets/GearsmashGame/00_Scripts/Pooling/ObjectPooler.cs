using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    
    public static ObjectPooler Instance;
    
    public List<Pool> Pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    public bool permissionIntantiate = true;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                
            }
            PoolDictionary.Add(pool.tag,objectPool);
            Debug.Log(PoolDictionary.Values);
            
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            Debug.LogError("Pool with tag " + tag + " Doesn't exist.");
            return null;
        }
        if (permissionIntantiate)
        {
            GameObject objectToSpawn =  PoolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();
            if (pooledObject != null)
            {
                pooledObject.OnObjectSpawn();
            }
            PoolDictionary[tag].Enqueue(objectToSpawn);
            StartCoroutine(SpawnGO());
            return objectToSpawn;
        }

        return null;
    }

    IEnumerator SpawnGO()
    {
        permissionIntantiate = false;
        yield return new WaitForSeconds(0.5f);
        permissionIntantiate = true;
        StopCoroutine(SpawnGO());
    }
}
