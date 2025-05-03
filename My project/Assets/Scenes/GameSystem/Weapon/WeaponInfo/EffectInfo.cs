using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/EffectData")]
public class EffectInfo : ScriptableObject
{
    public Vector2 SpawnLocation;
    public GameObject effectPrefab;
    //public AnimationClip attackAnimation;
}
