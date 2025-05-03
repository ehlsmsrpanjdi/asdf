using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using UnityEngine.InputSystem.XR;

/// <summary>
/// ��� �ִϸ��̼� �ڵ��� �������� �����̴�.
/// �ֳ��ϸ� statemanager�� ���� ������ 1������
/// �ִϸ��̼� ����̱� ����
/// ���յ� ������ �� �˺��ƴϰ�
/// ��� �ϴ� �ִϸ��̼��� ���� ���� �� �� ����
/// 
/// �ڽĿ� Renderer�� �ִٰ� Ȯ���ϰ�
/// �� �ڽ��� Renderer�� animatinohandle�� �����ð���
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
