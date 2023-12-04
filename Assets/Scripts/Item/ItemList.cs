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
    public string name;
    public ItemType type;
    public float maxSizeX = 2.8f; // 카메라 범위
    public float maxSizeY = 5f; // 카메라 범위
    public Rigidbody _rigidbody;

    public float speed = 10f; //임시
    public abstract void ItemEffect();
    public abstract void SpawnItem();


    protected void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        Move();       
    }

    protected void Move()
    {
        _rigidbody.AddForce(transform.forward*-speed,ForceMode.Force);
        if(this.transform.position.y <  -maxSizeY ) //일단 카메라 범위를 벗어나면 강제로 돌아가게 하는데 다른 이동방식을 생각 해 보기
        {
            
        }else if(this.transform.position.x > maxSizeX || this.transform.position.x < -maxSizeX)
        {

        }

    }
}
