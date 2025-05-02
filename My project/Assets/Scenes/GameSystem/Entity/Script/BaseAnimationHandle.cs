using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimationHandle : MonoBehaviour
{
    protected static readonly int IsMove = Animator.StringToHash("IsMove");
    protected static readonly int OnHit = Animator.StringToHash("OnHit");
    protected static readonly int OnAttack = Animator.StringToHash("Attack");

    protected Animator animator;


    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
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
