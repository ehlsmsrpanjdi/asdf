using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour
{
    public bool isWeaponEquipped { get; protected set; }

    public WeaponAnimHandler animationHandle;

    public BaseWeapon currentWeapon;

    [HideInInspector] public InputAction click;

    [HideInInspector] public PlayerInput playerInput;


    public GameObject WeaponPrefab;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        click = playerInput.actions["Click"];
        click.performed += OnClick => Attack();

        animationHandle = GetComponentInChildren<WeaponAnimHandler>();

        if(WeaponPrefab != null)
        {
            EquipmentWeapon(WeaponPrefab.GetComponent<BaseWeapon>());
        }
    }

    public void EquipmentWeapon(BaseWeapon _weapon)
    {
        currentWeapon = _weapon;
        animationHandle.Init(currentWeapon);
        currentWeapon.weaponStrategy.Init(animationHandle, this);
        isWeaponEquipped = true;
    }

    public void UnequipmentWeapon()
    {
        animationHandle.Release();
        currentWeapon = null;
        isWeaponEquipped = false;
    }

    public void Attack()
    {
        if (isWeaponEquipped == false) return;
        if (currentWeapon.CoolTimeOnly() == false) return;
        currentWeapon.weaponStrategy.Attack();
    }

    void Update()
    {
        if (isWeaponEquipped == false) return;
        currentWeapon.weaponStrategy.Update();
    }

    private void OnDestroy()
    {
        if (click != null)
        {
            click.performed -= OnClick => Attack();
        }
    }
}
