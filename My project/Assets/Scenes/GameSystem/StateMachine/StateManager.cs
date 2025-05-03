using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using UnityEngine.InputSystem.XR;

/// <summary>
/// 얘는 애니메이션 핸들을 갖고있을 예정이다.
/// 왜냐하면 statemanager의 존재 목적의 1순위는
/// 애니메이션 재생이기 때문
/// 결합도 응집도 다 알빠아니고
/// 얘는 일단 애니메이션을 위한 도구 중 한 개임
/// 
/// 자식에 Renderer가 있다고 확정하고
/// 그 자식의 Renderer의 animatinohandle을 가져올거임
/// </summary>
public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update

    protected Dictionary<StateEnum, StateMachine> stateDic = new Dictionary<StateEnum, StateMachine>();
    private bool isInit = false;

    protected StateMachine currentState = null;

    [HideInInspector] public BaseAnimationHandle animationHandle;

    private void Awake()
    {
        stateDic.Add(StateEnum.Idle, new IdleState());
        stateDic.Add(StateEnum.Move, new MoveState());
        stateDic.Add(StateEnum.Hit, new HitState());
        stateDic.Add(StateEnum.Attack, new AttackState());
        stateDic.Add(StateEnum.Jump, new JumpState());
        animationHandle = GetComponentInChildren<BaseAnimationHandle>();
    }

    public void Init()
    {
        if (isInit) return;

        isInit = true;

        foreach (KeyValuePair<StateEnum, StateMachine> state in stateDic)
        {
            state.Value.Init(this);
        }
    }

    public void ManagerUpdate()
    {
        currentState?.StateUpdate();
    }

    public void StateChange(StateEnum _Enum)
    {
        if (_Enum == currentState?.Type)
        {
            return;
        }

        if (_Enum == StateEnum.None)
        {
            return;
        }

        currentState?.StateExit();
        currentState = stateDic[_Enum];
        currentState.StateEnter();
    }
}
