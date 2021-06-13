using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] float detectionSize;
    [SerializeField] float detectionLength;
    [SerializeField] Vector2 lastMoveingDirection;
    [SerializeField] GameObject interactableArrow;

    [Space]

    [SerializeField] Collider2D detectedObj;
    [SerializeField] GameObject localDirectionDetector;
    [SerializeField] int InteractableLayer;
    [SerializeField] Interactable currentInteractable;


    void Update()
    {
        if( Input.GetKeyDown( KeyCode.W ) ) { lastMoveingDirection = Vector2.up * detectionLength;    }
        if( Input.GetKeyDown( KeyCode.S ) ) { lastMoveingDirection = Vector2.down * detectionLength;  }
        if( Input.GetKeyDown( KeyCode.A ) ) { lastMoveingDirection = Vector2.left * detectionLength;  }
        if( Input.GetKeyDown( KeyCode.D ) ) { lastMoveingDirection = Vector2.right * detectionLength; }
        
        localDirectionDetector.transform.localPosition = lastMoveingDirection;

        if( detectedObj != null && detectedObj.gameObject.layer == InteractableLayer )
        {
            if( currentInteractable == null )
                currentInteractable = detectedObj.GetComponent<Interactable>();

            interactableArrow.SetActive( true );
            interactableArrow.transform.position = currentInteractable.arrowBase.position;

            if( Input.GetKeyDown( KeyCode.E ) )
            {    
                // don't interact if inventory or shop open
                if( InventoryPanel.IsOpen || ShopPanel.IsOpen ) 
                    return;

                currentInteractable.GetInteracted();
            }
        }
        else
        {
            interactableArrow.SetActive( false );
        }
        
    }

    void FixedUpdate()
    {
        detectedObj = Physics2D.OverlapCircle ( localDirectionDetector.transform.position, detectionSize );
    }


}
