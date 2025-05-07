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
/// 특정 클래스에 종속되지 않을거기 때문에
/// controller와 statemanager
/// statuscollection과 animationhandle을 제외한 것들은
/// 최소화하게 접근할거임
/// 지금보면 특정 클래스가 아니라 모두 base클래스를 사용하는걸 볼 수 있음
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