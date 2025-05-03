using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponStatusCollection
{
    public float AttackTime = 1.0f;
    public float AttackTimeMax = 1.0f;

    public bool AttackTimeUpdate()
    {
        if (AttackTime > 0.01f)
        {
            AttackTime -= Time.deltaTime;
            return false;
        }
        AttackTime = 0.0f;
        return true;
    }

    public void DoAttack()
    {
        AttackTime = AttackTimeMax;
    }
}

