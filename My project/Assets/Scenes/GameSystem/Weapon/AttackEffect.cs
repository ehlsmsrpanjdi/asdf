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

    /// <summary>
    /// 1. Damage, 2. Speed, 3. LifeTime
    /// </summary>
    /// <param name="_Damage"></param>
    /// <param name="_Speed"></param>
    /// <param name="_LifeTime"></param>
    public void Init(float _Damage, float _Speed, float _LifeTime)
    {
        if (isInit) return;
        isInit = true;
        Damage = _Damage;
        Speed = _Speed;
        LifeTime = _LifeTime;
        Destroy(gameObject, LifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Enemy"))
        //{
            //Debug.Log("Hit");
            //Debug.Log("Hit");
            //collision.GetComponent<Enemy>().TakeDamage(Damage);
            //Destroy(gameObject);
        //}
    }

    public void Update()
    {
        
    }
}
