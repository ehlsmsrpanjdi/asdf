using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D rigidComponent;
    protected SpriteRenderer spriteRenderer;

    public float moveSpeed = 5.0f;

    protected Vector2 moveDirection;
    protected Vector2 mouseDirection;

    [HideInInspector] public InputAction move;
    [HideInInspector] public InputAction jump;
    [HideInInspector] public InputAction mouse;
    [HideInInspector] public InputAction click;

    Camera mainCamera;

    [HideInInspector] public PlayerInput playerInput;

    private StateManager stateManager = null;

    [HideInInspector] public StatusCollection statusCollection = new StatusCollection();

    void Start()
    {
        Init();
    }


    private void Update()
    {
        TotalMouseFunction();

        stateManager.ManagerUpdate();
    }


    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        moveDirection = move.ReadValue<Vector2>();
        if (moveDirection.sqrMagnitude < 0.01f)
        {
            stateManager.StateChange(StateEnum.Idle);
            return;
        }
        rigidComponent.MovePosition(rigidComponent.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        stateManager.StateChange(StateEnum.Move);
    }

    void TotalMouseFunction()
    {
        mouseDirection = mouse.ReadValue<Vector2>();

        MousePosCaculator(ref mouseDirection);

        bool check = PlayerDirectionCaculator(in mouseDirection);

        spriteRenderer.flipX = check ? false : true;
    }

    void MousePosCaculator(ref Vector2 _mousesPos)
    {
        _mousesPos = mainCamera.ScreenToWorldPoint(_mousesPos);
    }


    bool PlayerDirectionCaculator(in Vector2 _mousePos)
    {
        float playerX = transform.position.x;
        float mouseX = _mousePos.x;

        return playerX < mouseX ? true : false;
    }

    private bool isInit = false;

    void Init()
    {
        if (isInit) return;
        isInit = true;


        rigidComponent = GetComponent<Rigidbody2D>();
        spriteRenderer = GameObject.FindWithTag("Renderer").GetComponent<SpriteRenderer>();

        stateManager = GetComponent<StateManager>();
        stateManager.Init();

        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        jump = playerInput.actions["Jump"];
        mouse = playerInput.actions["Mouse"];
        click = playerInput.actions["Click"];

        mainCamera = Camera.main;
    }
}
