using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// 플레이어 스텟 및 무적시간 등등 관리해야해서
/// initializer 있어야함
/// </summary>
public class StatusCollection : Initializer
{
    public float moveSpeed = 5.0f;
    public Vector2 moveDirection;
    public Vector2 mouseDirection;

    bool isInit = false;
    public void Init()
    {
        if (isInit) return;
        isInit = true;
    }
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

    public void ManagerUpdate()
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
