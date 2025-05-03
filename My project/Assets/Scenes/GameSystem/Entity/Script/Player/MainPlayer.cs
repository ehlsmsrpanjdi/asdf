using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MainPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidComponent;
    BoxCollider2D collisionComponent;
    PlayerController playerController;
    StateManager stateManager;
    StatusCollection statusManager = new StatusCollection();
    PlayerSpriteObject playerSpriteObject;
    WeaponHandler weaponHandler;
    Camera mainCamera;

    Vector2 screenMousePos;


    void Start()
    {
        rigidComponent = GetComponent<Rigidbody2D>();
        collisionComponent = GetComponent<BoxCollider2D>();
        playerController = GetComponent<PlayerController>();
        stateManager = GetComponent<StateManager>();
        playerSpriteObject = GetComponentInChildren<PlayerSpriteObject>();
        weaponHandler = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponHandler>();
        mainCamera = Camera.main;

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Hit();
        }

        MousePosCaculator();
        stateManager.ManagerUpdate();
        statusManager.StatusUpdate();

        Vector2 playerPos = transform.position;
        playerSpriteObject.FlipUpdate(playerPos, screenMousePos);
    }

    private void FixedUpdate()
    {
        if (statusManager.moveDirection.sqrMagnitude < 0.01f)
        {
            stateManager.StateChange(StateEnum.Idle);
            return;
        }
        rigidComponent.MovePosition(rigidComponent.position + statusManager.moveDirection * statusManager.moveSpeed * Time.fixedDeltaTime);
    }


    void Move()
    {
        statusManager.moveDirection = playerController.move.ReadValue<Vector2>();

        stateManager.StateChange(StateEnum.Move);
    }

    void Attack()
    {
        if (weaponHandler.isEquipped == false) return;
        stateManager.StateChange(StateEnum.Attack);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hit();
        }
    }

    void Hit()
    {
        if(statusManager.IsGod() == true) return;
        statusManager.BeGod();
        stateManager.StateChange(StateEnum.Hit);
    }

    void Jump()
    {
        stateManager.StateChange(StateEnum.Jump);
    }


    void  MousePosCaculator()
    {
        statusManager.mouseDirection = playerController.mouse.ReadValue<Vector2>();
        screenMousePos = mainCamera.ScreenToWorldPoint(statusManager.mouseDirection);
    }

    void Init()
    {
        playerSpriteObject.Init();

        stateManager.Init();

        //weaponHandler.Init();

        playerController.Init();
        playerController.move.performed += ctx => Move();
        //playerController.mouse.performed += ctx => MousePosCaculator();
        playerController.click.performed += ctx => Attack();
        playerController.jump.performed += ctx => Jump();
    }
}
