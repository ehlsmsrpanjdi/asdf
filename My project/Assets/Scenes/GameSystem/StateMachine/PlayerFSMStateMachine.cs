using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public enum StateEnum
{
    None = -1,
    Idle = 0,
    Move,
    Hit,
    Attack,
    Jump,
    Handled,
    JumpGame,
}

/// <summary>
/// Ư�� Ŭ������ ���ӵ��� �����ű� ������
/// controller�� statemanager
/// statuscollection�� animationhandle�� ������ �͵���
/// �ּ�ȭ�ϰ� �����Ұ���
/// ���ݺ��� Ư�� Ŭ������ �ƴ϶� ��� baseŬ������ ����ϴ°� �� �� ����
/// </summary>
public abstract class StateMachine
{
    protected StateManager stateManager;


    [HideInInspector] public StateEnum Type { get; protected set; }

    public abstract void Init(StateManager _manager);
    public abstract void StateEnter();
    public abstract void StateUpdate();
    public abstract void StateExit();
}

public class IdleState : StateMachine
{
    public override void Init(StateManager _manager)
    {
        stateManager = _manager;
        Type = StateEnum.Idle;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
    }

    public override void StateUpdate()
    {
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
    }
}

public class MoveState : StateMachine
{
    public override void Init(StateManager _manager)
    {
        stateManager = _manager;
        Type = StateEnum.Move;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
        stateManager.animationHandle.Move(true);
    }

    public override void StateUpdate()
    {
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
        stateManager.animationHandle.Move(false);
    }
}


public class AttackState : StateMachine
{
    public override void Init(StateManager _manager)
    {
        stateManager = _manager;
        Type = StateEnum.Attack;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
    }

    public override void StateUpdate()
    {
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
    }
}

public class HitState : StateMachine
{
    public override void Init(StateManager _manager)
    {
        stateManager = _manager;
        Type = StateEnum.Hit;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
        stateManager.animationHandle.Hit(true);
    }

    public override void StateUpdate()
    {
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
        stateManager.animationHandle.Hit(false);
    }
}


public class JumpState : StateMachine
{
    public override void Init(StateManager _manager)
    {
        stateManager = _manager;
        Type = StateEnum.Jump;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
    }

    public override void StateUpdate()
    {
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
    }
}

public class HandleState : StateMachine
{
    public override void Init(StateManager _manager)
    {
        stateManager = _manager;
        Type = StateEnum.Hit;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
    }

    public override void StateUpdate()
    {
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
    }
}

public class JumpGameState : StateMachine
{
    public override void Init(StateManager _manager)
    {
        stateManager = _manager;
        Type = StateEnum.JumpGame;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
    }

    public override void StateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
    }
}