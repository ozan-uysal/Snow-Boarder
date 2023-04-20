using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    PlayerController instance;
    bool _isGrounded;
    [SerializeField] GameObject Onur;
    bool doubleJump;
    bool canJump;
    //Vector2 playerVelocity;

    [SerializeField] float torque = 1f;
    [SerializeField] int forceAmountY = 1;
    Vector2 jumpPower;
    void Start()
    {
        instance = this;
        _isGrounded = false;
        canJump = false;
        jumpPower = new Vector2(0, forceAmountY);

        //playerVelocity =  instance.GetComponent<Rigidbody2D>().velocity;
    }
    void FixedUpdate()
    {
        //_isGrounded = GameObject.Find("GroundCheck").GetComponent<GroundCheck>().IsGrounded;
        RotateLeft();
        RotateRight();
        Jump();
    }
    void Update()
    {
        

        if (_isGrounded && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if ((Input.GetButtonDown("Jump") && _isGrounded) || (Input.GetButtonDown("Jump") && doubleJump))
        {
            canJump = true;
        }
    }
    //void CharacterControll()
    //{
    //    RotateLeft();
    //    RotateRight();
    //    Jump();
    //}
    void Jump()
    {
        _isGrounded = Onur.GetComponentInChildren<GroundCheck>().IsGrounded;
        Debug.Log("DoubleJump = " + doubleJump);
        if (canJump)
        {
            rb2D.AddForce(jumpPower);
            doubleJump = !doubleJump;
        }
    }
    void RotateRight()
    {
       if (Input.GetKey(KeyCode.D))
        {
            rb2D.AddTorque(-torque,ForceMode2D.Force);
        }
    }
    void RotateLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2D.AddTorque(torque,ForceMode2D.Force);
        }
    }
}
