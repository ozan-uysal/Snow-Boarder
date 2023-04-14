using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     Rigidbody2D rg2D;

    [SerializeField] float torque = 1f;
    [SerializeField] float forceAmountY = 1f;
    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
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
}
