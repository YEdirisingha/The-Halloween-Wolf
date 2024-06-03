using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
   
    private float playerSpeed = 5.0f ;
    private Vector3 moveVector;
    private Animator animator;

    

    private float gravity=9.8f;
    private float moveVectorY;
    public AudioSource bgMusic;
    public float jumpSpeed;

    private float animationDuration = 3.0f;

    private bool isDead = false;
    private bool isJumped;
    private bool isLeft;
    private bool isRight; 

    private float startTime;

    public static int coinsCount;
    public Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
        coinsCount = 0;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead)
            return;

        coinsText.text = "Coins : " + coinsCount;
        

        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * playerSpeed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;
        

        
        // x (player move left and right)
        moveVector.x = Input.GetAxisRaw("Horizontal") * playerSpeed;

        if (isLeft)
        {
            moveVector.x = -playerSpeed;
        }
        if (isRight)
        {
            moveVector.x = playerSpeed;
        }
        
        //y (player jump and down
        if (controller.isGrounded)
        {
            moveVectorY = -0.5f;
            if (Input.GetKeyDown(KeyCode.Space) || isJumped )
            {
                moveVectorY = jumpSpeed;
                animator.SetBool("isJump", true);
            }
            else
            {
                animator.SetBool("isJump", false);
                
            }
        }
        moveVectorY -= gravity * Time.deltaTime;

        moveVector.y = moveVectorY;
      

        //z(forward and backword)
        moveVector.z = playerSpeed;

        controller.Move(moveVector * Time.deltaTime);

    }
    public void setSpeed(float modifire)
    {
        playerSpeed = 5.0f + modifire;
    }
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag=="Enemy")
        {
            Death();
        }
    }
    public void Death()
    {
        isDead = true;
        bgMusic.Pause();
        GetComponent<Score>().onDeath();
        animator.SetBool("isDead", true);
    }

    public void isjumpp()
    {
        isJumped = true;
    }

    public void overjump()
    {
        isJumped = false;
    }

    public void isleftt()
    {
        isLeft = true;
    }
    public void isLeftOff()
    {
        isLeft = false;
    }
    public void isRightt()
    {
        isRight = true;
    } 
    public void isRightOff()
    {
        isRight = false;
    }
}
