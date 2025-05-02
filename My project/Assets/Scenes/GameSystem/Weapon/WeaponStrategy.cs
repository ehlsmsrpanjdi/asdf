using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Ranged,
    Melee,
}

public abstract class  WeaponStrategy
{
    public BaseAnimationHandle animationHandle;
    public WeaponHandler weaponHandler;
    public WeaponType weaponType { get; protected set; }
    public virtual void Init(BaseAnimationHandle _animationHandle, WeaponHandler _weaponHandler)
    {
        animationHandle = _animationHandle;
        weaponHandler = _weaponHandler;
    }

    public abstract void Attack();

    public abstract void Update();

    public abstract void Reload();
}


public class  RangedWeapon : WeaponStrategy
{
    public override void Init(BaseAnimationHandle _animationHandle, WeaponHandler _weaponHandler)
    {
        weaponType = WeaponType.Ranged;
        animationHandle = _animationHandle;
        weaponHandler = _weaponHandler;
    }

    public override void Attack()
    {
        animationHandle.Attack(true);
    }
    public override void Reload()
    {

    }

    public override void Update()
    {

    }
}

public class MeleeWeapon : WeaponStrategy
{
    public override void Init(BaseAnimationHandle _animationHandle, WeaponHandler _weaponHandler)
    {
        weaponType = WeaponType.Ranged;
        animationHandle = _animationHandle;
        weaponHandler = _weaponHandler;
    }

    public override void Attack()
    {

    }
    public override void Reload()
    {

    }
    public override void Update()
    {

    }
}