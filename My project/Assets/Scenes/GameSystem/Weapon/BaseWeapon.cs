using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public Animator animator;
    public WeaponStrategy weaponStrategy;
    public StatusCollection weaponStatus;

    public WeaponType weaponType;


    public void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        weaponStatus = new StatusCollection();
        switch (weaponType)
        {
            case WeaponType.Ranged:
                weaponStrategy = new RangedWeapon();
                break;
            case WeaponType.Melee:
                weaponStrategy = new MeleeWeapon();
                break;
            default:
                break;
        }
    }

    public bool CoolTimeOnly()
    {
        if (weaponStatus.AttackTime > 0.01f)
        {
            return false;
        }
        return true;
    }
    public bool CoolTimeUpdate()
    {
        return weaponStatus.AttackTimeUpdate();
    }
}
