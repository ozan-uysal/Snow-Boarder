using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    bool _isGrounded;
    [SerializeField] GameObject onur;
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
    }
    void FixedUpdate()
    {
        CharacterRotator();
        Jump();
        PlayerAddForce();
    }
    void Update()
    {
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
    //void RotateRight()
    //{
    //   if (Input.GetKey(KeyCode.D))
    //    {
    //        rb2D.AddTorque(-torque,ForceMode2D.Force);
    //    }
    //}
    //void RotateLeft()
    //{
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        rb2D.AddTorque(torque,ForceMode2D.Force);
    //    }
    //}
    void CharacterRotator()
    {
        float horizontalForce = -Input.GetAxis("Horizontal")*torqueMultipler;
        rb2D.AddTorque(horizontalForce,ForceMode2D.Force);
    }
    void PlayerAddForce()
    {
    }
}
