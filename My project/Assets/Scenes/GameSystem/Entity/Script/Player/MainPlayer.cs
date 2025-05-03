using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MainPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidComponent;
    Collision2D collisionComponent;
    PlayerController playerController;
    StateManager stateManager;
    StatusCollection statusManager = new StatusCollection();
    PlayerSpriteObject playerSpriteObject;
    Camera mainCamera;

    Vector2 screenMousePos;


    void Start()
    {
        rigidComponent = GetComponent<Rigidbody2D>();
        collisionComponent = GetComponent<Collision2D>();
        playerController = GetComponent<PlayerController>();
        stateManager = GetComponent<StateManager>();
        playerSpriteObject = GetComponentInChildren<PlayerSpriteObject>();
        mainCamera = Camera.main;

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = transform.position;
        stateManager.ManagerUpdate();
        playerSpriteObject.FlipUpdate(playerPos, screenMousePos);
    }

    private void FixedUpdate()
    {
        rigidComponent.MovePosition(rigidComponent.position + statusManager.moveDirection * statusManager.moveSpeed * Time.fixedDeltaTime);
    }

    void Move()
    {
        statusManager.moveDirection = playerController.move.ReadValue<Vector2>();
        if (statusManager.moveDirection.sqrMagnitude < 0.01f)
        {
            stateManager.StateChange(StateEnum.Idle);
            return;
        }
        stateManager.StateChange(StateEnum.Move);
    }

    void Attack()
    {
        stateManager.StateChange(StateEnum.Attack);
    }

    void DirectionCalculation()
    {
        statusManager.mouseDirection = playerController.mouse.ReadValue<Vector2>();
    }

    void Jump()
    {

    }


    void  MousePosCaculator()
    {
        statusManager.mouseDirection = playerController.mouse.ReadValue<Vector2>();
        screenMousePos = mainCamera.ScreenToWorldPoint(statusManager.mouseDirection);
    }

    void Init()
    {
        playerController.move.performed += ctx => Move();
        playerController.mouse.performed += ctx => MousePosCaculator();
        playerController.click.performed += ctx => Attack();
        playerController.jump.performed += ctx => Jump();
    }
}
