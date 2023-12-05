using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputContoller : PlayerCharacterContoller
{
    private Camera _camera;    
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Awake()
    {
        _camera = Camera.main;

        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();  
    }


    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnAttack(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}

//void update()
//{
//    float h = Input.GetAxisRaw("Horizontal");
//    if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
//        h = 0;

//    float h = Input.GetAxisRaw("Vertical");
//    if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
//        v = 0;

//    Vector3 curPos = Transform.position;
//    Vector3 nextPos = new Vector3(h, V, 0) * Speed * Time.deltaTime;

//    Transform.position = curPos + nextPos;
//}

//if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
//{
//    anim.GetInteger("Input", (int)h);
//}
