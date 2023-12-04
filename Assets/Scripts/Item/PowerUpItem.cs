using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : ItemList
{
    public PowerUpItem()
    {
        name = "PowerUp";
        type = ItemType.PowerUp;
       
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
}
