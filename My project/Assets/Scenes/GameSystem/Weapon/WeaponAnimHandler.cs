using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAnimHandler : BaseAnimationHandle
{
    SpriteRenderer spriteRenderer;


    public void Init(BaseWeapon _weapon)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _weapon.spriteRenderer.sprite;

        animator.runtimeAnimatorController = _weapon.animator.runtimeAnimatorController;
    }

    public void Release()
    {
        spriteRenderer.sprite = null;
        animator.runtimeAnimatorController = null;  
    }
}
