using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;
using System;
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

    public float speed = 3.0f;
    public float enemyHp;

    public float shotDelay;
    public float maxShotDelay = 2f;

    private float moveDelay;
    private float maxMoveDelay = 2f;

    public Transform bulletPos;
    public GameObject bulletObj;

    public GameObject player;

    Rigidbody2D rigidbody;
    
    Animator anim;
    BoxCollider2D boxCollider;
    CircleCollider2D circleCollider;
    PolygonCollider2D polygonCollider;

    public event Action<Vector3> DieEnemyEvent; 

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();

        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();

        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        Move();
    }

    void Update()
    {
        EnemyAttack();
    }

    private void Move()
    {
        switch (enemyType)
        {
            case EnemyType.EnemyA:
                StartCoroutine(MovementA());
                break;
            case EnemyType.EnemyB:
                StartCoroutine(MovementB());
                break;
            case EnemyType.EnemyC:
                StartCoroutine(MovementC());
                break;
        }
    }
    
    IEnumerator MovementA()
    {
        int ranPointY = UnityEngine.Random.Range(1, 5);
        int ranPointX = UnityEngine.Random.Range(-2, 3);
        Vector2 ranVec = new Vector2(ranPointX, ranPointY);
        transform.DOMove(ranVec, 2);
        yield return null;
    }

    IEnumerator MovementB()
    {
        while (true)
        {
            float ranPointY = UnityEngine.Random.Range(1f, 5f);
            float ranPointX = UnityEngine.Random.Range(-2.2f, 2.2f);
            Vector2 randomPosition = new Vector2(ranPointX, ranPointY);

            while (Vector2.Distance(transform.position, randomPosition) > 0.1f)
            {
                transform.DOMove(randomPosition, 3);
                yield return null;
            }

            yield return new WaitForSeconds(maxMoveDelay);
        }
    }
    

    IEnumerator MovementC()
    {
        float ranPointY = UnityEngine.Random.Range(0f, 3f);
        Vector2 randomPosition = new Vector2(transform.position.x, ranPointY);
        transform.DOMove(randomPosition, 7);

        yield return null;
    }
    private void EnemyAttack()
    {
        switch (enemyType)
        {
            case EnemyType.EnemyA:
                AttackA();
                break;
            case EnemyType.EnemyB:
                AttackB();
                break;
            case EnemyType.EnemyC:
                AttackC();
                break;
        }
    }
    void AttackA()
    {
        shotDelay += Time.deltaTime;
        if (shotDelay >= maxShotDelay)
        {
            GameObject instantBullet = Instantiate(bulletObj, bulletPos.position, bulletPos.rotation);
            Rigidbody2D bulletRigidbody = instantBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = bulletPos.forward * 2;
            bulletRigidbody.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            maxShotDelay = UnityEngine.Random.Range(3f, 5f);
            shotDelay = 0;
        }
    }

    
    void AttackB()
    {
        maxShotDelay = 2f;
        shotDelay += Time.deltaTime;
        if (shotDelay >= maxShotDelay)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject instantBullet = Instantiate(bulletObj, bulletPos.position, bulletPos.rotation);
                instantBullet.transform.position = transform.position;
                Vector2 bulletDir = Vector2.down;
                bulletDir.x -= 0.3f;
                bulletDir.x += 0.3f * i;
                instantBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir * 5, ForceMode2D.Impulse);
            }
            shotDelay = 0;
            maxShotDelay = UnityEngine.Random.Range(3f, 4f);
        }
    }

    void AttackC()
    {
        maxShotDelay = 2f;
        shotDelay += Time.deltaTime;
        if (shotDelay >= maxShotDelay)
        {
            if (player != null)
            {
                GameObject instantBullet = Instantiate(bulletObj, bulletPos.position, bulletPos.rotation);
                instantBullet.transform.position = transform.position;
                Vector2 bulletDir = player.transform.position - transform.position;

                instantBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * 5, ForceMode2D.Impulse);
                shotDelay = 0;
                maxShotDelay = UnityEngine.Random.Range(3f, 4f);
            }
            else
            {
                player = GameObject.FindWithTag("Player");
            }

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            OnHit(1);
        }
    }
    void OnHit (int damage)
    {        
        enemyHp -= damage;
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit);

        anim.SetTrigger("isHit");

        if (enemyHp <= 0)
        {            
            anim.SetTrigger("OnExplosion");
            int ItemRan = UnityEngine.Random.Range(0, 10);
            if (ItemRan < 2)
            {
                GameManager.I.SpawnItem(this.transform.position);
            }
            
            Destroy(this.gameObject,0.5f);

            switch (enemyType)
            {
                case EnemyType.EnemyA:
                    GameManager.I.UpdateScore(10);
                    transform.localScale = Vector3.one * 0.7f;
                    
                    circleCollider.enabled = false;
                    break;
                case EnemyType.EnemyB:
                    GameManager.I.UpdateScore(50);
                    transform.localScale = Vector3.one * 1f;
                    polygonCollider.enabled = false;
                    break;
                case EnemyType.EnemyC:
                    GameManager.I.UpdateScore(100);
                    transform.localScale = Vector3.one * 2f;
                    boxCollider.enabled = false;
                    break;
            }
        }
        
    }

    

}
