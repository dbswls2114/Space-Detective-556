using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : ItemList
{
    public event Action EatPowerUpItem;
    protected override void Start()
    {
        name = "PowerUp";
        type = ItemType.PowerUp;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void SpawnItem()
    {
        Instantiate(this, transform);
    }
    public override void ItemEffect()
    {
        //총알의 크기를 키우고(콜라이더도)
        //재발사 대기시간도 줄이고
        //만약 데미지가 있다면 데미지도 올린다.
    }
    public void CallEatPowerUpItem()
    {
        EatPowerUpItem?.Invoke();
        //플레이어 움직임 코드 어딘가에 이 아이템을 먹었을때 호출하게 짜야댐 어디다 짜지
        // 충돌처리 부분이 완료되면 넣으면 될듯
    }
}
