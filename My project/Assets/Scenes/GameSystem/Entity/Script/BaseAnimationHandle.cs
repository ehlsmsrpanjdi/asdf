using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// initalizer �Ⱥ��� ������
/// ������ �� �� ȣ���ϰ� tick�ȵ���
/// �÷��̾ �������� Ȯ���� �ʹ� ����
/// </summary>
public class BaseAnimationHandle : MonoBehaviour
{
    protected static readonly int IsMove = Animator.StringToHash("IsMove");
    protected static readonly int OnHit = Animator.StringToHash("OnHit");
    protected static readonly int OnAttack = Animator.StringToHash("Attack");
    protected static readonly int OnJump = Animator.StringToHash("Jump");

    protected Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimationController(RuntimeAnimatorController _Controller)
    {
        animator.runtimeAnimatorController = _Controller;
    }

    public virtual void Move(bool _bool)
    {
        animator.SetBool(IsMove, _bool);
    }

    public virtual void Hit(bool _bool)
    {
        animator.SetBool(OnHit, _bool);
    }

    public virtual void Attack(bool _bool)
    {
        animator.SetBool(OnAttack, _bool);
    }
}
