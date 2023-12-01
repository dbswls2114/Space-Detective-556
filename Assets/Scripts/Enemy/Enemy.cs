using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using TMPro;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        EnemyA,
        EnemyB,
        EnemyC
    };

    public EnemyType enemyType;
    Vector2 pos;
    float delta = 2.0f;

    public float speed = 3.0f;
    public float enemyHp;

    public float ShotDelay;
    float MaxShotDelay = 1.5f;

    public Transform bulletPos;
    public GameObject bulletObj;

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;


    public float moveDelay;
    public float maxMoveDelay;



    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        pos = transform.position;
        //StartCoroutine(ForceMove());
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Attack());
    }

    IEnumerator ForceMove()
    {
        //pos += Vector2.down * 0.01f;
        //int ranPointY = Random.Range(1, 5);
        //int ranPointX = Random.Range(-2, 3);
        //Vector2 ranVec = new Vector2(ranPointX, ranPointY);
        //transform.DOMove(ranVec, 2);

        int ranPointY = Random.Range(1, 5);
        int ranPointX = Random.Range(-2, 3);
        Vector2 pos = new Vector2(ranPointX, ranPointY);
        transform.DOMove(pos, 2);

        yield return null;
    }

    void MovementA()
    {
        //pos += Vector2.down * 0.01f;
        int ranPointY = Random.Range(1, 5);
        int ranPointX = Random.Range(-2, 3);
        Vector2 ranVec = new Vector2(ranPointX, ranPointY);
        transform.DOMove(ranVec, 2);
        //transform.position = Vector3.Slerp(gameObject.transform.position, ranVec.transform.position, 0.05f);

    }
    private void Move()
    {
        switch (enemyType)
        {
            case EnemyType.EnemyA:
                //StartCoroutine(ForceMove());
                MovementA();
                    break;
            case EnemyType.EnemyB:
                MovementB();
                break;
            case EnemyType.EnemyC:
                MovementC();
                break;
        }
    }
    void MovementB()
    {
        //float moveDelay;
        //float maxMoveDelay;

        moveDelay += Time.deltaTime;
        if (moveDelay >= maxMoveDelay)
        {
            Debug.Log("MovementB");
            float ranPointY = Random.Range(1, 5);
            float ranPointX = Random.Range(-2, 3);
            Vector2 pos = new Vector2(ranPointX, ranPointY);
            transform.DOMove(pos, 2);
            maxMoveDelay = Random.Range(2, 5);
            moveDelay = 0;
        }
        //moveDelay += Time.deltaTime;
        //if (moveDelay >= maxMoveDelay)
        //{
        //    int ranPointY = Random.Range(1, 5);
        //    int ranPointX = Random.Range(-2, 3);
        //    Vector2 pos = new Vector2(ranPointX, ranPointY);
        //    transform.DOMove(pos, 2);
        //    maxMoveDelay = Random.Range(2, 5);
        //    moveDelay = 0;
        //}
        //Vector2 repeatMovement = pos;
        //repeatMovement.x = Random.Range(1, 3);
        //repeatMovement.y = Random.Range(-2, 2);
        //Vector2 ranVec = new Vector2(repeatMovement.x, repeatMovement.y);
        //transform.DOMove(ranVec, 2);
    }

    void MovementC()
    {
        pos += Vector2.down * 0.01f;

    }



    IEnumerator Attack()
    {
        ShotDelay += Time.deltaTime;
        //Bullet ¼ÒÈ¯
        if (ShotDelay >= MaxShotDelay)
        {
            //Debug.Log("Attack");
            GameObject intantBullet = Instantiate(bulletObj, bulletPos.position, bulletPos.rotation);
            Rigidbody2D bulletRigidbody = intantBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = bulletPos.forward * 2;
            bulletRigidbody.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
            ShotDelay = 0;
        }
        yield return null;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Bullet")
    //    {
    //        Debug.Log("Bullet Hit!");
    //        StartCoroutine(OnDamage());
    //        Destroy(other.gameObject);
    //    }
    //}

    //IEnumerator OnDamage()
    //{
    //    Debug.Log("OnDamage");
    //    //enemyHp -= damage;
    //    //MyMaterial.color = Color.red;
    //    if (enemyHp > 0)
    //    {
    //        //MyMaterial.color = new Color(1,1,1);
    //    }

    //    if ( enemyHp < 0)
    //    {
    //        StartCoroutine(Disappearing());
    //    }
    //    yield return new WaitForSeconds(0.2f);
    //}

    //IEnumerator Disappearing()
    //{
    //    Debug.Log("Disappearing");
    //    Destroy(this.gameObject);
    //    yield return null;
    //}
}
