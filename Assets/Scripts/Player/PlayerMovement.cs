using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( PlayerAnimation ) )]
public class PlayerMovement : MonoBehaviour
{

    PlayerAnimation playerAnimation;
    AudioSource audioSource;

    public bool isPlayingSFX = false;



    [SerializeField] float movementSpeed;

    [SerializeField] Vector3 movementDirection;


    void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        movementDirection = new Vector3 ( H, V, 0 );

        playerAnimation.UpdateAnimation( movementDirection );

        playerAnimation.

        transform.position = Vector3.Lerp
        (
            transform.position, 
            transform.position + movementDirection,
            movementSpeed * Time.deltaTime
        );

        if( (H!=0 || V!=0) && isPlayingSFX== false)
        {
            audioSource.Play();
            isPlayingSFX = true;
        }
        else if ((H == 0 && V == 0)&& isPlayingSFX == true)
        {
            audioSource.Pause();
            isPlayingSFX = false;
        }
    }




}
