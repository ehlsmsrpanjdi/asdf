using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// initalizer 안붙인 이유는
/// 어차피 한 번 호출하고 tick안돌고
/// 플레이어가 갖고있을 확률이 너무 낮음
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
