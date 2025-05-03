using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSpriteObject : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipUpdate(in Vector2 _player, in Vector2 _mouse)
    {
        spriteRenderer.flipX = _player.x > _mouse.x ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
