using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackPooler : MonoBehaviour
{
    public void SetBackPoolerObject()
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.parent = FindObjectOfType<PoolManager>().transform;
    }
}
