using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatusCollection
{
    public float GodTime
    {
        get; set;
    }
    public float GodTimeMax
    {
        get { return 1.5f; }
        private set { GodTimeMax = value; }
    }

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

    public void BeGod()
    {
        GodTime = GodTimeMax;
    }

    /// <summary>
    /// godtime is 0.01f or less return true;
    /// </summary>
    /// <returns></returns>
    public bool GodTimeUpdate()
    {
        if (GodTime > 0.01f)
        {
            GodTime -= Time.deltaTime;
            return false;
        }
        GodTime = 0.0f;
        return true;
    }
}
