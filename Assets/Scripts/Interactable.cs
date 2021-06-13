using UnityEngine;
using UnityEngine.Events;
public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent OnInteractedEvent;
    
    public Transform arrowBase;

    public void GetInteracted()
    {
        OnInteractedEvent.Invoke();
    }
    
}
