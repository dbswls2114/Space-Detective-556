using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : ItemList
{
    // Start is called before the first frame update
    protected override void Start()
    {
        name = "Bomb";
        type = ItemType.Bomb;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void SpawnItem()
    {
        Instantiate(this, transform);
    }
   
    public override void ItemEffect()
    {
        //폭탄 카운트 추가(플레이어에 있는)
    }

    public void BombItemUse()
    {
        // 게임매니저에서 호출?
        // 전체 적 처치?
        // 폭탄카운트 하나뺴기(플레이어한테서)
    }
}
