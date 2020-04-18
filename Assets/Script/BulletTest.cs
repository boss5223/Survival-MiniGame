using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    //    private float yposV;
    //    private float xposV;
    //    public Rigidbody2D rb;
    //    private float PLAyposV;
    //    private float PLAxposV;

    //    // Use this for initialization
    //    void Start()
    //    {
    //        rb = GetComponent<Rigidbody2D>();
    //        // This stuff makes the object point towards the mouse pointer when it first spawns, but not again.
    //        var pos = Camera.main.WorldToScreenPoint(transform.position);
    //        var dir = Input.mousePosition - pos;
    //        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //        //
    //        PLAyposV = GameObject.Find("Player").GetComponent<PlayerAttack>().playerYpos; //Finding the players X and Y position from another script and then moving the projectile to it.
    //        PLAxposV = GameObject.Find("Player").GetComponent<PlayerAttack>().playerXpos;
    //        transform.position = new Vector2(PLAxposV, PLAyposV);
    //    }

    //    void Update()
    //    {
    //        yposV = transform.position.y;
    //        xposV = transform.position.x;
    //        transform.position += transform.forward * Time.deltaTime;  // This line
    //    }
    //}
}
