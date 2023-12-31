using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayeriveMovement : MonoBehaviour
{
    private PlayerCharacterContoller _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    Animator anim;

    private void Awake()
    {
        _controller = GetComponent<PlayerCharacterContoller>();
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        if (GameManager.I.Alive == true)
        {
            ApplyMovment(_movementDirection);
        } else
        {
            ApplyMovment(Vector2.zero);
        }
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }
    
    private void ApplyMovment(Vector2 direction)
    {
        anim.SetInteger("Input", (int)direction.x);
        
        direction = direction * 5;

        _rigidbody.velocity = direction;
    }
}
