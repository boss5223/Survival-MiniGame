using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PlayerController
{
    Vector2 direction;
    // Update is called once per frame
    void Start()
    {
       
        direction = new Vector2(rightjoystick.Horizontal, rightjoystick.Vertical);
    }
    void Update()
    {
        Vector2 direct = direction;
        Rotate(direct);
    }
    public override void Rotate(Vector2 direct)
    {
        if (direct.x == -1)
        {
            rigidbody.velocity = Vector2.left * 90 ;
        }
        else if (direct.x == 1)
        {
            rigidbody.velocity = Vector2.right * 90;
        }
        else if (direct.y == 1)
        {
            rigidbody.velocity = Vector2.up * 90;
        }
        else if (direct.y == -1)
        {
            rigidbody.velocity = Vector2.down * 90;
        }
    }
}
