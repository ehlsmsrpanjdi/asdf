
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
    public Sprite weaponImage;

    public GameObject GetEffect()
    {
        return effectInfo.effectPrefab;
    }

    public RuntimeAnimatorController weaponAnimation;
    public EffectInfo effectInfo;
}