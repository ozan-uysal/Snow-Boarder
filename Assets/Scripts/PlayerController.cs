using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    bool _isGrounded;
    [SerializeField] GameObject onur;

    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] ParticleSystem particleEffect;
    bool doubleJump;
    bool canJump;
    Vector2 jumpPower;

    //Vector2 playerVelocity;

    [SerializeField] float torqueMultipler = 1f;
    [SerializeField] int forceAmountY = 1;
    [SerializeField] int forceAmountX = 1;
    
    void Start()
    {
        _isGrounded = false;
        canJump = false;
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }
    void FixedUpdate()
    {
        CharacterRotator();
        Jump();
        PlayerAddForce();
    }
    void Update()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.V))
        {
            forceAmountX = forceAmountX * 2;
            Debug.Log("v pressed");
        }

        jumpPower = new Vector2(0, forceAmountY);

        if (_isGrounded && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if ((Input.GetButtonDown("Jump") && _isGrounded) || (Input.GetButtonDown("Jump") && doubleJump))
        {
            canJump = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Finish")
        {
           particleEffect.Play();
        }
    }
    void Jump()
    {
        _isGrounded = onur.GetComponentInChildren<GroundCheck>().IsGrounded;
        
        //Debug.Log("DoubleJump = " + doubleJump);
        if (canJump)
        {
            rb2D.AddForce(jumpPower);
            doubleJump = !doubleJump;
            canJump = false;
        }
    }
    void CharacterRotator()
    {
        float horizontalForce = -Input.GetAxis("Horizontal")*torqueMultipler;
        rb2D.AddTorque(horizontalForce,ForceMode2D.Force);
    }
    void PlayerAddForce()
    {
        //Debug.Log("isGrounded = " +  _isGrounded);
        if (_isGrounded)
        { 
            rb2D.AddForce(new Vector2(forceAmountX, 0));
        }
      
    }  
}
