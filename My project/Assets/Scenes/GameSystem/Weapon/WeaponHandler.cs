using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// 플레이어의 무기관리를 해주는 시스템이여서
/// 초기화 및 관리가 반드시 필요해서
/// Initializer넣었음
/// </summary>
public class WeaponHandler : MonoBehaviour, Initializer
{
    [HideInInspector] public bool isEquipped { get; protected set; } = false;

    WeaponAnimHandler animationHandle;
    SpriteRenderer spriteRenderer;


    GameObject attackEffect;

    string weaponName;
    float damage;
    float speed;

    float maxAttackTime;
    float attackTime;
    float lifeTime;



    WeaponInfo selectedInfo;

    public void Init()
    {
        animationHandle = GetComponent<WeaponAnimHandler>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void WeaponOn(WeaponInfo _Info)
    {
        isEquipped = true;
        selectedInfo = _Info;

        weaponName = _Info.weaponName;
        damage = _Info.damage;
        speed = _Info.speed;
        maxAttackTime = _Info.attackTime;
        lifeTime = _Info.effectDuration;

        spriteRenderer.sprite = _Info.weaponImage;

        //public AnimationClip attackAnimation;
        //public EffectInfo effectInfo;
        animationHandle.SetAnimationController(_Info.weaponAnimation);
        attackEffect = _Info.GetEffect();
    }

    public void WeaponOff()
    {
        selectedInfo = null;
        isEquipped = false;
        animationHandle.SetAnimationController(null);
        attackEffect = null;
        attackTime = 0;
        spriteRenderer.sprite = null;
    }

    public void ManagerUpdate()
    {
        if (isEquipped == false) return;
        if (attackTime > 0.01f)
        {
            attackTime -= Time.deltaTime;
            return;
        }
        attackTime = 0;
        animationHandle.Attack(false);
    }


    public void Attack()
    {
        if (CanAttack() == false)
        {
            Debug.Log("Attack Cooldown");
            return;
        }
        Debug.Log("Attack");

        attackTime = maxAttackTime;
        animationHandle.Attack(true);
        GameObject obj = Instantiate(attackEffect, transform.position, Quaternion.identity);
        obj.GetComponent<AttackEffect>().Init(damage, speed, lifeTime);
    }

    public bool CanAttack() => attackTime < 0.001f;
}
