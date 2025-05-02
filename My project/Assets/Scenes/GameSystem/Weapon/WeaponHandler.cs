using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
     public BaseAnimationHandle animationHandle;
    public WeaponStrategy weaponStrategy;

    void Start()
    {
        animationHandle = GetComponent<BaseAnimationHandle>();
        //weaponStrategy = new WeaponStrategy();
    }

    public void Attack()
    {
        weaponStrategy?.Attack();
    }
    void Update()
    {
        weaponStrategy?.Update();
    }
}
