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
    public event Action EatItem;
    public int Life = 3;

    public GameManager manager;

    private float _timeSinceLastAttack = float.MaxValue;
    public float reroad = 0.2f;
    protected bool IsAttacking { get; set; }


    void Start()
    {
        EatItem += EatPowerUpItem;
    }
    protected virtual void Update()
    {
        PlayerAttackDelay();
    }

    private void PlayerAttackDelay()
    {
        if (_timeSinceLastAttack <= reroad)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > reroad)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }

    //�ǰ�ó��
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            gameObject.SetActive(false);
            Life--;
            GameManager.I.UpdateLifeIcon();
            Debug.Log("1hit 1hit");
            if (Life == 0)
            {
                GameManager.I.GameOver();
            }
            else
            {
                GameManager.I.PlayerRespawn();
            }
            //���� �� �ִϸ��̼�
        }
        if (collision.gameObject.tag == "PowerUpItem")
        {
            EatItem?.Invoke();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "PowerUpItem")
        {
            EatItem?.Invoke();
            Destroy(collision.gameObject);
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
        reroad *= 0.9f;
    }
}
