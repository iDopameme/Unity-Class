using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour {
    private int currentScene;
    public float xSpeed, maxSpeed, acceleration;
    public float speed;
    public Rigidbody2D ribody;
    public float jumpForce;//=500f;
    public bool jump;
    private bool IsGround = false;
    private bool IsDying = false;
    private bool IsWalk, IsJump, Idle;
    public Transform groundCheck;
    private Animator anima;
    public LayerMask groundLayers;
    public GameObject Player1;

    // Use this for initialization
    void Start () {
        xSpeed = 0;
        maxSpeed = 8;
        acceleration = 10;
        speed = 4f;
        ribody = GetComponent<Rigidbody2D>();
        jumpForce = 1;
        jump = false;
        anima = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {            
            jump = true;
        } 
    }
    void FixedUpdate()
    {
        IsGround = Physics2D.OverlapCircle(groundCheck.position, .01f, groundLayers);// need change
        anima.SetBool("IsGround", IsGround);
        if (jump && IsGround)   //space is pressed and the player isn't already jumping and the player is grounded
        {
            ribody.AddForce(new Vector2(0, jumpForce));    //add the force to have the player jump            
        }
        else if (!IsGround)
        {
            jump = false;
        }
        // left
        if (Input.GetKey(KeyCode.A)&& xSpeed>-maxSpeed) { 
            anima.SetBool("IsWalk", true);
            xSpeed = xSpeed - acceleration*(Time.deltaTime);
            Flip();
        }
        // right
        else if (Input.GetKey(KeyCode.D) && xSpeed < -maxSpeed)
        {
            anima.SetBool("IsWalk", true);
            xSpeed = xSpeed + acceleration * (Time.deltaTime);
        }
       // Vector3 motion = new Vector3(xSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.gameObject.tag == "key")
        {
            Debug.Log("got the Key");
            AudioManager.Instance.PlaySoundEffect(0);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "coin")
        {
            Debug.Log("got the Key");
            AudioManager.Instance.PlaySoundEffect(1);
            Destroy(collision.gameObject);
            //life=life+5
            //count ++;
            //life=life+(count/3);
        }
        if (collision.gameObject.tag == "bomb")
        {
            Debug.Log("Hit the bomb");
            IsDying = true;
            AudioManager.Instance.PlaySoundEffect(2);
            Destroy(collision.gameObject);//
        }
        /* if (currentScene == 1)
              Player1.transform.position = new Vector3(-6.2f, 0.5f, 0f);//change player bagan position
         else if (currentScene == 2)
              Player1.transform.position = new Vector3(-7.6f, -0.13f, 0f);//change player bagan position 
         else
              Player1.transform.position = new Vector3(-7.6f, -0.13f, 0f);*/
    }

    void Flip()
    {
        //facingRight = !facingRight;
        Vector3 playerScale = this.transform.localScale;
        playerScale.x *= -1;
        this.transform.localScale = playerScale;
    }
}

/*
   private void OnCollisionEnter2D(Collision2D collision)
   {
       if (collision.gameObject.tag == "powerup!!!")
       {
           Debug.Log("powerup!!!");
           Destroy(collision.collider.gameObject);
       }
       if (collision.gameObject.name == "RightBorder")
       {
           xSpeed = 0;
           updateXPos = false;
       }
       if (collision.gameObject.name == "TopBorder")
       {
           ySpeed = 0;
           updateYNeg = false;            
       }
       if (collision.gameObject.name == "LeftBorder")
       {
           xSpeed = 0;
           updateXNeg = false;
       }
       if (collision.gameObject.name == "BottomBorder")
       {
           ySpeed = 0;
           updateYPos = false;
       }
   }
   private void OnCollisionExit2D(Collision2D collision)
   {
       if (collision.gameObject.name == "RightBorder")
       {
           updateXPos = true;
       }
       if (collision.gameObject.name == "TopBorder")
       {
           updateYNeg = true;
       }
       if (collision.gameObject.name == "LeftBorder")
       {
           updateXNeg = true;
       }
       if (collision.gameObject.name == "BottomBorder")
       {
           updateYPos = true;
       }
   }
   */

