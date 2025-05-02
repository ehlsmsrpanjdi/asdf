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
}

/// <summary>
/// 특정 클래스에 종속되지 않을거기 때문에
/// controller와 statemanager
/// statuscollection과 animationhandle을 제외한 것들은
/// 최소화하게 접근할거임
/// 지금보면 특정 클래스가 아니라 모두 base클래스를 사용하는걸 볼 수 있음
/// </summary>
public abstract class StateMachine
{
    protected BaseController controller;
    protected StateManager stateManager;


    [HideInInspector] public StateEnum Type { get; protected set; }

    public abstract void Init(MonoBehaviour _object, StateManager _manager);
    public abstract void StateEnter();
    public abstract void StateUpdate();
    public abstract void StateExit();
}

public class IdleState : StateMachine
{
    public override void Init(MonoBehaviour _object, StateManager _manager)
    {
        stateManager = _manager;
        controller = _object as BaseController;
        Type = StateEnum.Idle;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
    }

    public override void StateUpdate()
    {
        Debug.Log("State Update");
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
    }
}

public class MoveState : StateMachine
{
    public override void Init(MonoBehaviour _object, StateManager _manager)
    {
        stateManager = _manager;
        controller = _object as BaseController;
        Type = StateEnum.Move;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
        stateManager.animationHandle.Move(true);
    }

    public override void StateUpdate()
    {
        Debug.Log("State Update");
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
        stateManager.animationHandle.Move(false);
    }
}


public class AttackState : StateMachine
{
    public override void Init(MonoBehaviour _object, StateManager _manager)
    {
        stateManager = _manager;
        controller = _object as BaseController;
        Type = StateEnum.Attack;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
    }

    public override void StateUpdate()
    {
        Debug.Log("State Update");
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
    }
}

public class HitState : StateMachine
{
    public override void Init(MonoBehaviour _object, StateManager _manager)
    {
        stateManager = _manager;
        controller = _object as BaseController;
        Type = StateEnum.Hit;
    }

    public override void StateEnter()
    {
        Debug.Log("State Enter");
        stateManager.animationHandle.Hit(true);
        controller.statusCollection.BeGod();
    }

    public override void StateUpdate()
    {
        Debug.Log("State Update");
        if (controller.statusCollection.GodUpdate())
        {
            stateManager.StateChange(StateEnum.Idle);
        }
    }

    public override void StateExit()
    {
        Debug.Log("State Exit");
        stateManager.animationHandle.Hit(false);
    }
}
