using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputContoller : MonoBehaviour
{
    private Camera _camera;
    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    

    
    private void Awake()
    {
        _camera = Camera.main;
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();  
    }

    
    int speed = 10;
    private void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y축으로 이동할양
        transform.Translate(new Vector3(xMove, yMove, 0));  //이동
       

        if (xMove > 0) // 오른쪽으로 이동 중
        {
            spriteRenderer.flipX = false; // 좌우 반전 없음
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", true);
        }
        else if (xMove < 0) // 왼쪽으로 이동 중
        {
            spriteRenderer.flipX = false; // 좌우 반전
            anim.SetBool("isLeft", true);
            anim.SetBool("isRight", false);
        }
        else // 정지 상태
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
    }


    //public void OnMove(InputValue value)
    //{
    //    Vector2 LookInput = value.Get<Vector2>().normalized;
    //    CallMoveEvent(LookInput);
    //}

}
