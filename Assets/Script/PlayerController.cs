using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    Vector2 bulletdirection;
    [HideInInspector]
    public float rotateBullet;
    [HideInInspector]
    public Vector2 rotate;
    // Start is called before the first frame update
    [SerializeField]private LayerMask layerMask;
    public float jumpvelocity = 25f;
    [HideInInspector]public FixedJoystick joystick;
    [HideInInspector]public RightJoyStick rightjoystick;
    public GameObject muzzle_R;
    public GameObject muzzle_L;

    private JumpButton jumpbutton;
    [HideInInspector]public Rigidbody2D rigidbody;
    private BoxCollider2D box2D;
    private Animator animator;
    private float dt = 0.7f;
    private float time = 0;
    bool flipfaceright;
    void Awake()
    {
        joystick = FindObjectOfType<FixedJoystick>();
        rightjoystick = FindObjectOfType<RightJoyStick>();
        jumpbutton = FindObjectOfType<JumpButton>();
        box2D = transform.GetComponent<BoxCollider2D>();
        rigidbody = transform.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        PoolManager.instance.CreateParticle(muzzle_R, 1);
        PoolManager.instance.CreateParticle(muzzle_L, 1);
    }

    // Update is called once per frame
    void Update()
    {
        characterMove();
        cooldownJump(dt);
        cooldownFireParticle(time);
        bulletdirection = new Vector2(rightjoystick.Horizontal, rightjoystick.Vertical);
        Rotate(bulletdirection);
    }
    public void Init()
    {
        DeregisterEvent();
        IsDeath = false;
        
    }
    void characterMove()
    {
        if (onGrounded() && jumpbutton.Pressed && dt >= 0.7|| onGrounded() && Input.GetKey(KeyCode.Space) && dt >= 1)
        {
            rigidbody.velocity = Vector2.up * jumpvelocity;
            Animation_SetBool("Jump", true);
            dt = 0; 
        }
        else
        {
            Animation_SetBool("Jump", false);
        }
        rigidbody.velocity = new Vector2((joystick.Horizontal + Input.GetAxis("Horizontal")) * 30, rigidbody.velocity.y);
        Flip(rigidbody.velocity);
        AnimatorSpeed();
        Animation_SetFloat("Speed", rigidbody.velocity.x);

        if (rigidbody.velocity.x < 0)
        {
            Animation_SetFloat("Speed", 1);
        }
        else if(rigidbody.velocity.x == 0)
        {
            Animation_SetBool("Idle", true);
        }
        
    }
    public virtual void Rotate(Vector2 bulletdirection)
    {
        //bulletdirection = new Vector2(rightjoystick.Horizontal, rightjoystick.Vertical);
        if (bulletdirection.x == -1)
        {
           
            Animation_SetInt("Direction", 1);
            StartCoroutine(StartFireParticle_L());
        }
        else if (bulletdirection.x == 1)
        {
            Animation_SetInt("Direction", 2);
            StartCoroutine(StartFireParticle_R());
        }
        else if (bulletdirection.y == 1)
        {
            
        }
        else if (bulletdirection.y == -1)
        {
            
        }
        else if(bulletdirection.x ==0 && bulletdirection.y == 0)
        {
            Animation_SetInt("Direction", 0);
        }

    }
    IEnumerator StartFireParticle_L()
    {
        yield return new WaitForSeconds(0.2f);
        PoolManager.instance.ReuseParticle(muzzle_L, transform.position, Quaternion.identity);
    }
    IEnumerator StartFireParticle_R()
    {
        yield return new WaitForSeconds(0.2f);
        PoolManager.instance.ReuseParticle(muzzle_R, transform.position, Quaternion.identity);
    }

    private void AnimatorSpeed()
    {
        if (joystick.Horizontal < 0 && rightjoystick.Horizontal == 0 && rightjoystick.Vertical == 0)
        {
            animator.speed = joystick.Horizontal * -1;
        }
        else if (joystick.Horizontal > 0 && rightjoystick.Horizontal == 0 && rightjoystick.Vertical == 0)
        {
            animator.speed = joystick.Horizontal;
        }
        else if (rightjoystick.Horizontal !=0|| rightjoystick.Vertical != 0)
        {
            animator.speed = 1f;
        }
    }
    private void Flip(Vector2 direction)
    {
        if(direction.x > 0 && !flipfaceright && bulletdirection.x ==0|| direction.x < 0 && flipfaceright && bulletdirection.x == 0)
        {
            flipfaceright = !flipfaceright;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        else if(bulletdirection.x != 0)
        {
            Vector2 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
            flipfaceright = false;
        }
    }
    private bool onGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(box2D.bounds.center, box2D.bounds.size, 0f, Vector2.down ,1f, layerMask);
        return raycastHit2D.collider != null;
    }
    private void  cooldownJump(float dt)
    {
        this.dt = dt + Time.deltaTime;
    }
    private void cooldownFireParticle(float time)
    {
        this.time = time + Time.deltaTime;
    }
    private void Die()
    {
        IsDeath = true;
        
    }

    //Animation
    #region Animation
    public void Animation_SetBool(string anim, bool type)
    {
        animator.SetBool(anim, type);
    }
    public void Animation_SetFloat(string anim, float speed)
    {
        animator.SetFloat(anim, speed);
    }
    public void Animation_SetInt(string anim, int num)
    {
        animator.SetInteger(anim, num);
    }
    #endregion Animation
}
