using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    SetBackPooler getbackPooler;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Monster"))
        {

            Destroy(gameObject);
            //this.gameObject.SetActive(false);
            //this.gameObject.transform.parent = FindObjectOfType<PoolManager>().transform;
        }
        if (other.CompareTag("Monster"))
        {
                GameObject hit_monster = other.gameObject;
                MonsterAttribute stat = hit_monster.GetComponent<MonsterAttribute>();
                stat.GetHit();
            Destroy(gameObject);
        }

        
     
    }
}
