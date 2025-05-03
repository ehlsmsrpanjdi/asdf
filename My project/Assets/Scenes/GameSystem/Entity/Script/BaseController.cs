using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D rigidComponent;
    protected SpriteRenderer spriteRenderer;
    protected WeaponHandler weaponHandler;

    public float moveSpeed = 5.0f;

    public float jumpPower = 5.0f;

    protected StateManager stateManager = null;

    [HideInInspector] public StatusCollection statusCollection = new StatusCollection();

}
