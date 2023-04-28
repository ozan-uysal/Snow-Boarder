using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask platformLayerMask;
    [SerializeField] bool isGrounded;
     public bool IsGrounded { get { return isGrounded; } }
    void Start()
    {
        isGrounded = false;
    }
    void OnCollisionStay2D(Collision2D collider)
    {
        isGrounded = collider != null && (((1<<collider.gameObject.layer) & platformLayerMask) != 0);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded= false;
    }
}
