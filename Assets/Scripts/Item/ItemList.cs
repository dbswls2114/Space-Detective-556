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
    public float maxSizeX = 2.8f; // ī�޶� ����
    public float maxSizeY = 5f; // ī�޶� ����
    public Rigidbody2D _rigidbody;

    public float speed = 1f; //�ӽ�
    public abstract void ItemEffect(); //�Ⱦ�
    public abstract void SpawnItem(); //�Ⱦ�

    private Vector2 move = new Vector2(1, -1);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        int spawnVectorX = Random.Range(-1, 1);
        move.x = spawnVectorX;
    }

    protected virtual void Start()
    {
        
        
    }

    protected void FixedUpdate()
    {
        Move();
    }

    
    protected void Move()
    {
        _rigidbody.velocity = move*speed;
        if (this.transform.position.y <  -maxSizeY || this.transform.position.y >= maxSizeY) //�ϴ� ī�޶� ������ ����� ������ ���ư��� �ϴµ� �ٸ� �̵������ ���� �� ����
        {
            move = new Vector2(this.transform.position.x,this.transform.position.y*-1).normalized;
        }
        if(this.transform.position.x >= maxSizeX || this.transform.position.x < -maxSizeX)
        {
            move = new Vector2(this.transform.position.x * -1,this.transform.position.y).normalized;
        }
    }   
}
