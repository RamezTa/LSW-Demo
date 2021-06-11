using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    [SerializeField] Transform target;
    [SerializeField] float followSpeed;
    
    Vector3 delta;
    
    void Start()
    {
        if( target != null )
        {
            delta = transform.position - target.transform.position;
        }
        else
        {
            Debug.LogError("Camera Target Not Set!");
        }
    }

    
    void Update()
    {
        if( target == null )
            return;

        transform.position = Vector3.Lerp( transform.position, target.transform.position + delta, followSpeed * Time.deltaTime );
    }


}
