
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/WeaponData")]
public class WeaponInfo : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float attackTime;
    public float speed;
    public float effectDuration;

    
    public AnimationClip attackAnimation;
    public EffectInfo effectInfo;
}