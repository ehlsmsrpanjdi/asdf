using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSpriteObject : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    bool isInit = false;

    public void Init()
    {
        if (isInit) return;
        isInit = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipUpdate(in Vector2 _player, in Vector2 _mouse)
    {
        spriteRenderer.flipX = _player.x > _mouse.x ? true : false;
    }


}
