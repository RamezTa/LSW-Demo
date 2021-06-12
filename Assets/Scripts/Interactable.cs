using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    
    public void SetHighted( bool x )
    {
        print("SetHighted:" + x);
    }

    public void SetSelected( bool x )
    {
        print("SetSelected:" + x);
    }
    
}
