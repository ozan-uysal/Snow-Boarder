using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg2D;
    PlayerController instance;
    bool _isGrounded;

    [SerializeField] float torque = 1f;
    [SerializeField] int forceAmountY = 1; 
    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
        instance = this;
        _isGrounded = false;
    }
    void Update()
    {
        _isGrounded = GameObject.Find("GroundCheck").GetComponent<GroundCheck>().IsGrounded;
       
            
        Debug.Log(_isGrounded);
        if (Input.GetKey(KeyCode.A))
        {
            rg2D.AddTorque(torque);
        }
        else if(Input.GetKey(KeyCode.D)) 
        {
            rg2D.AddTorque(-torque);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2Int(0, forceAmountY));
        }
    }
}
