using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public class Pool
    {
        public string tag;
        public GameObject bullet;
        public int size;
    }
    public List<Pool> pooling;
    public Dictionary<string,Queue<GameObject>> poolDictionary;
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pooling)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i=0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.bullet);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
