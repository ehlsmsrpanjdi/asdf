using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class AttackEffect : MonoBehaviour
{
    BoxCollider2D boxCollider;

    float Damage;
    float Speed;
    float LifeTime;
    bool isInit = false;

    public void Init(float _Damage, float _Speed, float _LifeTime)
    {
        if (isInit) return;
        isInit = true;
        Damage = _Damage;
        Speed = _Speed;
        LifeTime = _LifeTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            //Debug.Log("Hit");
            //collision.GetComponent<Enemy>().TakeDamage(Damage);
            //Destroy(gameObject);
        }
    }
}
