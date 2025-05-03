using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponStatusCollection
{
    public float AttackTime = 1.0f;
    public float AttackTimeMax = 1.0f;

    public float Damage = 10.0f;

    public void AttackTimeUpdate()
    {
        if (AttackTime > 0.01f)
        {
            AttackTime -= Time.deltaTime;
        }
        AttackTime = 0.0f;
    }

    public bool CanAttack() => AttackTime > 0.001f ? false : true;

    public void DoAttack() => AttackTime = AttackTimeMax;
}

