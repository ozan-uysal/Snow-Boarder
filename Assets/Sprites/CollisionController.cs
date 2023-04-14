using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] int forceAmountY = 100;
    CollisionController instance;
     void Start()
    {     
        instance = this;
    }
    private void OnCollisionStay2D(Collision2D other)
    
    {
        if (Input.GetKey(KeyCode.Space))
        {
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2Int(0, forceAmountY));
            Debug.Log(forceAmountY);
        }
    }
}
