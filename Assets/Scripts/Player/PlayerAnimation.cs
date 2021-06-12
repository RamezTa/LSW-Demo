using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    [SerializeField] Animator animator;
    [SerializeField] Transform body;

    void Update()
    {
        
    }


    public void UpdateAnimation( Vector2 movement )
    {
        UpdateFaceDirection( movement.x );

        if( movement.x == 0 && movement.y == 0 )
        {   // idle legs
            animator.SetInteger("State", 0);
        }
        else 
        {   // running legs
            animator.SetInteger("State", 2);
        }
    }


    // just filp the sacel of the body on the X
    void UpdateFaceDirection( float horizontal )
    {
        if( horizontal > 0 )
        {
            body.localScale = new Vector3 ( 1,1,1 );
        }
        else if( horizontal < 0 )
        {
            body.localScale = new Vector3 ( -1,1,1 );
        }
    }

}
