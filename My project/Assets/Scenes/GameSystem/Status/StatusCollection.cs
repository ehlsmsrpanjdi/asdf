using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatusCollection
{
    public float moveSpeed = 5.0f;
    public Vector2 moveDirection;
    public Vector2 mouseDirection;

    public float GodTime
    {
        get; set;
    }
    public float GodTimeMax
    {
        get { return 1.5f; }
        private set { GodTimeMax = value; }
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
