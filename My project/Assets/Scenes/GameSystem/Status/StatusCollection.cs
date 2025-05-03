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
        get; protected set;
    }
    public float GodTimeMax
    {
        get { return 1.5f; }
        protected set { GodTimeMax = value; }
    }
    public void BeGod() => GodTime = GodTimeMax;

    public bool IsGod() => GodTime > 0.001f ? true : false;

    public void StatusUpdate()
    {
        GodTimeUpdate();
    }

    /// <summary>
    /// godtime is 0.01f or less return true;
    /// </summary>
    /// <returns></returns>
    public void GodTimeUpdate()
    {
        if (GodTime > 0.01f)
        {
            GodTime -= Time.deltaTime;
        }
        GodTime = 0.0f;
    }
}
