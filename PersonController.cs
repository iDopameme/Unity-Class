using UnityEngine;
using System.Collections;

public class PersonController : MonoBehaviour
{
    public float speed = 200f;
    public float jumpForce = 800f;
    private float xSpeed;
    public float acceleration, deceleration, maxSpeed;
    public bool IsGround;
    public Transform groundCheck;
    public LayerMask groundLayers;
    private float groundCheckRadius = .2f;
    public bool jump;
    private bool facingRight, Idle;
    private Animator anim;
    public static bool abc = false;
    // private int currentScene;

    public static bool IsDying = false;
    //public bool Open;
    private float horizontalMotion = 0f;//verticalMotion=0f

    // Use this for initialization
    void Start()
    {
        maxSpeed = 5;
        xSpeed = 0;
        acceleration = 10;
        deceleration = 10;
        // rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //jump = false;
        facingRight = true;
        Idle = true;
        anim.SetBool("Idle", true);
    }

    // Update is called once per frame - used for button/key presses
    void Update()
    {
        horizontalMotion = Input.GetAxis("Horizontal");    //X  get the horizontal motion, if any
        //verticalMotion = Input.GetAxis("Vertical");        //X  get the vertical motion, if any
        if (Input.GetKeyDown(KeyCode.Space))
        {//GetButtonDown("Jump")
            jump = true;
        }
        if (abc == true&& Time.time >=10f)
        {
            abc = false;
        }
           
        //if (IsDying == true)
        //    IsDying = false;
    }

    void FixedUpdate()
    {
        IsGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);
        anim.SetBool("IsGround", IsGround);
        if (jump == true && IsGround)   //space is pressed and the player isn't already jumping and the player is grounded
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0);
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
        else if (!IsGround)
        {
            jump = false;
        }
        jump = false;
        float moveX = Input.GetAxis("Horizontal");
        if ((Input.GetKey(KeyCode.A)) && (xSpeed > -maxSpeed))
            xSpeed = xSpeed - acceleration * Time.deltaTime;
        else if ((Input.GetKey(KeyCode.D)) && (xSpeed < maxSpeed))
            xSpeed = xSpeed + acceleration * Time.deltaTime;
        else
        {
            if (xSpeed > deceleration * Time.deltaTime)
                xSpeed = xSpeed - deceleration * Time.deltaTime;
            else if (xSpeed < -deceleration * Time.deltaTime)
                xSpeed = xSpeed + deceleration * Time.deltaTime;
            else
                xSpeed = 0;
        }
        Vector2 moving = new Vector2(xSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (moveX != 0f)
        {
            Idle = false;
        }
        else
        {
            Idle = true;
        }
        anim.SetBool("Idle", Idle);
        if ((moveX > 0.0f && !facingRight) || (moveX < 0.0f && facingRight))
        {
            Flip();
        }
        GetComponent<Rigidbody2D>().velocity = moving;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 playerScale = this.transform.localScale;
        playerScale.x *= -1;
        this.transform.localScale = playerScale;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Trigger function
    {
        if (collision.gameObject.tag == "coin")
        {
            Debug.Log("Player has collected = " + collision.gameObject.tag);
            AudioManager.Instance.PlaySoundEffect(1);
            Destroy(collision.gameObject);
        }
        if (abc==true && collision.gameObject.tag == "door")
        {
            Debug.Log("Player reach the door");
            TransitionManager.gonext = true;
            AudioManager.Instance.PlaySoundEffect(5);
        }

    }
}
