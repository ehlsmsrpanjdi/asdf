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

    private List<Initializer> initializers = new List<Initializer>();


    void Start()
    {
        rigidComponent = GetComponent<Rigidbody2D>();
        collisionComponent = GetComponent<BoxCollider2D>();
        playerController = GetComponent<PlayerController>();
        stateManager = GetComponent<StateManager>();
        playerSpriteObject = GetComponentInChildren<PlayerSpriteObject>();
        weaponHandler = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponHandler>();
        mainCamera = Camera.main;

        initializers.Add(playerController);
        initializers.Add(stateManager);
        initializers.Add(statusManager);
        initializers.Add(playerSpriteObject);
        initializers.Add(weaponHandler);
        //�÷��̾ �ݵ�� �����־���ϰ�, ������Ʈ�� �ʿ��� ��ü���� 
        //��� �� initializer�� ���� �� �÷��̾ ������Ʈ���� ���� ȣ��


        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))        //������ �Լ� ������ ����
        {
            OnHit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            weaponHandler.WeaponOn(GameInstance.GetInst().GetWeaponInfo("Sword"));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            weaponHandler.WeaponOn(GameInstance.GetInst().GetWeaponInfo("Hammer"));
        }

        MouseFunction();

        initializers.ForEach(updateObject => updateObject.ManagerUpdate());

        //stateManager.ManagerUpdate();
        //statusManager.ManagerUpdate();
        //weaponHandler.ManagerUpdate();

    }

    void MouseFunction()
    {
        MousePosCaculator();
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
        //stateManager.StateChange(StateEnum.Attack);
        weaponHandler.Attack();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnHit();
        }
    }

    void OnHit()
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
        initializers.ForEach(x => x.Init());  //�ƴ� �̰� �� ����?

        //���ε��� �������ִ°� ���̰� ���� �÷��̾ ��������� ���ִ°� ���� �� ����
        playerController.move.performed += ctx => Move();
        //playerController.mouse.performed += ctx => MousePosCaculator();
        playerController.click.performed += ctx => Attack();
        playerController.jump.performed += ctx => Jump();
    }
}
