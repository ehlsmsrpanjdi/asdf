using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour
{
    public bool isEquipped { get; protected set; }

    public WeaponAnimHandler animationHandle;

    public WeaponStrategy weaponStrategy;

    //public WeaponInfo;

    //void WeaponOn();
    //void WeaponOff();

    public void WeaponUpdate()
    {

    }

    public void Attack()
    {
        weaponStrategy.Attack();
    }
}
