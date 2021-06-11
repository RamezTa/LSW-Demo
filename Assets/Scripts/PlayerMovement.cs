using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed;

    void Update()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        transform.position = Vector3.Lerp
        (
            transform.position, 
            transform.position + new Vector3 ( H, V, 0 ),
            movementSpeed * Time.deltaTime
        );
    }



}
