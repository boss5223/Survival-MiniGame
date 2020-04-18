using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    Rigidbody2D rbMonster;
    Animator monsterAnim;
    bool directionRight;
    public float speed ;
    // Start is called before the first frame update
    void Start()
    {
        rbMonster = transform.GetComponent<Rigidbody2D>();
        monsterAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        
        if (directionRight)
        {
            rbMonster.velocity = Vector2.right * speed;
            monsterAnim.SetInteger("Direction", 0);
        }
        else if (!directionRight)
        {
            rbMonster.velocity = Vector2.left * speed;
            monsterAnim.SetInteger("Direction", 1);
        }
    }
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (directionRight)
            {
                rbMonster.velocity = Vector2.right * speed;
                directionRight = false;
                //monsterAnim.SetInteger("Direction", 1);
            }
            else if (!directionRight)
            {
                rbMonster.velocity = Vector2.left * speed;
                directionRight = true;
                //monsterAnim.SetInteger("Direction", 0);
            }
        }
    }
}
