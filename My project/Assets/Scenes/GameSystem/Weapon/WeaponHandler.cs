using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour
{
    public bool isWeaponEquipped { get; protected set; }

    public WeaponAnimHandler animationHandle;
}
