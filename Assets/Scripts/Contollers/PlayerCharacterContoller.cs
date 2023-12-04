using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterContoller : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    public float reroad = 0.2f;
    protected bool IsAttacking { get; set; }


    public PowerUpItem _PowerUpItem;

    void Start()
    {
        _PowerUpItem.EatPowerUpItem += EatPowerUpItem;
    }
    protected virtual void Update()
    {
        PlayerAttackDelay();
    }

    private void PlayerAttackDelay()
    {
        if(_timeSinceLastAttack <= reroad)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        
        if (IsAttacking && _timeSinceLastAttack > reroad)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }
    
    //피격처리
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
    private void EatPowerUpItem()
    {
        reroad *= -0.2f;
    }
}
