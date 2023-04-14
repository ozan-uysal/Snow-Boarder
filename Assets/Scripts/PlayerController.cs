using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg2D;

    PlayerController instance;

    [SerializeField] float torque = 1f;
    [SerializeField] int forceAmountY = 1;
    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
        instance = this;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rg2D.AddTorque(torque);
        }
        else if(Input.GetKey(KeyCode.D)) 
        {
            rg2D.AddTorque(-torque);
        }
    }
  
    void OnCollisionStay2D(Collision2D other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2Int(0, forceAmountY));
        }
    }

}
