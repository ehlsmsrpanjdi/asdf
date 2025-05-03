using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// 얘도 update 없지만, 플레이어가 반드시 갖고있어야해서 넣음
/// </summary>
public class PlayerSpriteObject : MonoBehaviour, Initializer
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

    public void ManagerUpdate()
    {

    }

    public void FlipUpdate(in Vector2 _player, in Vector2 _mouse)
    {
        spriteRenderer.flipX = _player.x > _mouse.x ? true : false;
    }


}
