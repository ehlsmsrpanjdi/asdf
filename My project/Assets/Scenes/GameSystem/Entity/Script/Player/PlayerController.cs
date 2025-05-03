using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
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
}
