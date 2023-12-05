using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    PowerUp,
    Bomb
}

 public abstract class ItemList : MonoBehaviour
{
    public string itemName;
    public ItemType type;
    public float maxSizeX = 2.8f; // 카메라 범위
    public float maxSizeY = 5f; // 카메라 범위
    public Rigidbody2D _rigidbody;

    public float speed = 1f; //임시
    public abstract void ItemEffect(); //안씀
    public abstract void SpawnItem(); //안씀

    public Vector2 move = new Vector2(1, 1);

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

    protected void FixedUpdate()
    {
        Move();
    }

    
    protected void Move()
    {
        _rigidbody.velocity = move*speed;
        if (this.transform.position.y <  -maxSizeY || this.transform.position.y >= maxSizeY) //일단 카메라 범위를 벗어나면 강제로 돌아가게 하는데 다른 이동방식을 생각 해 보기
        {
            move = new Vector2(this.transform.position.x,this.transform.position.y*-1).normalized;
        }
        if(this.transform.position.x >= maxSizeX || this.transform.position.x < -maxSizeX)
        {
            move = new Vector2(this.transform.position.x * -1,this.transform.position.y).normalized;
        }
    }   
}
