using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// update없어서 initializer 안넣으려했는데
/// 플레이어가 갖고있는게 너무 명확하고
/// 초기화를 반드시해야해서 넣음
/// </summary>
public class PlayerController : BaseController, Initializer
{
    [HideInInspector] public InputAction move;
    [HideInInspector] public InputAction jump;
    [HideInInspector] public InputAction mouse;
    [HideInInspector] public InputAction click;

    [HideInInspector] public PlayerInput playerInput;


    public void Init()
    {
        if (isInit) return;
        isInit = true;

        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        jump = playerInput.actions["Jump"];
        mouse = playerInput.actions["Mouse"];
        click = playerInput.actions["Click"];
    }

    public void ManagerUpdate()
    {

    }
}
