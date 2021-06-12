using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] float detectionSize;
    [SerializeField] float detectionLength;
    [SerializeField] Vector2 lastMoveingDirection;

    [Space]

    [SerializeField] Collider2D detectedObj;


    void Update()
    {
        if( Input.GetKeyDown( KeyCode.W ) ) { lastMoveingDirection = Vector2.up;    }
        if( Input.GetKeyDown( KeyCode.S ) ) { lastMoveingDirection = Vector2.down;  }
        if( Input.GetKeyDown( KeyCode.A ) ) { lastMoveingDirection = Vector2.left;  }
        if( Input.GetKeyDown( KeyCode.D ) ) { lastMoveingDirection = Vector2.right; }
    }

    void FixedUpdate()
    {
        detectedObj = Physics2D.OverlapCircle ( lastMoveingDirection, detectionSize );

        // if (hit.collider != null)
        // {
        //     print(hit.collider.gameObject.name);


        // }

    }


}
