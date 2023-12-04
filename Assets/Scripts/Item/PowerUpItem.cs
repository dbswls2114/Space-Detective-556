using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : ItemList
{
    public PowerUpItem()
    {
        name = "PowerUp";
        type = ItemType.PowerUp;
        _rigidbody = this.GetComponent<Rigidbody>();
    }
    public override void SpawnItem()
    {
        throw new System.NotImplementedException();
    }
    public override void ItemEffect()
    {
        throw new System.NotImplementedException();
    }
}
