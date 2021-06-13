using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(SpriteRenderer) )]
public class SpriteChanger : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite targetSprite;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        
    }
    
    public void ChangeSprite()
    {
        spriteRenderer.sprite = targetSprite;
    }
    
}
