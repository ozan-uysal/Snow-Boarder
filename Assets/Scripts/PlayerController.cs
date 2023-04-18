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
    //Vector2 playerVelocity;

    [SerializeField] float torque = 1f;
    [SerializeField] int forceAmountY = 1; 
    void Start()
    {
        instance = this;
        _isGrounded = false;
        //playerVelocity =  instance.GetComponent<Rigidbody2D>().velocity;
    }
    void Update()
    {
        //_isGrounded = GameObject.Find("GroundCheck").GetComponent<GroundCheck>().IsGrounded;
        CharacterControll();
    }
    void CharacterControll()
    {
        RotateLeft();
        RotateRight();
        Jump();
    }
    void Jump()
    {
        
        if (_isGrounded && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        _isGrounded = Onur.GetComponentInChildren<GroundCheck>().IsGrounded;
        Debug.Log("DoubleJump = " + doubleJump);
        if ((Input.GetButtonDown("Jump") && _isGrounded) || (Input.GetButtonDown("Jump") && doubleJump))
        {
            rb2D.AddForce(new Vector2(0,forceAmountY));
            doubleJump = !doubleJump;
        }
    }
    void RotateRight()
    {
       if (Input.GetKey(KeyCode.D))
        {
            rb2D.AddTorque(-torque);
        }
    }
    void RotateLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2D.AddTorque(torque);
        }
    }
}
