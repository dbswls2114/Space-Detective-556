using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType 
    { 
        EnemyA, 
        EnemyB
    };

    public EnemyType enemyType;
    Vector2 pos;
    float delta = 2.0f;
    float circleR;
    float deg;
    float objSpeed;
    public float speed = 3.0f;
    public float enemyHp;

    public float ShotDelay;
    float MaxShotDelay = 1.5f;

    public Transform bulletPos;
    public GameObject bulletObj;

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        StartCoroutine(Attack());
    }
    private void Move()
    {
        switch (enemyType)
        {
            case EnemyType.EnemyA:
                //Debug.Log("Move");
                Vector2 v = pos;
                v.x += delta * Mathf.Sin(Time.time * speed);
                transform.position = v;

                break;
            case EnemyType.EnemyB:
                //deg += Time.deltaTime * objSpeed;
                //if (deg < 360)
                //{
                //    var red = Mathf.Deg2Rad * (deg);
                //    var x = circleR * Mathf.Sin(red);
                //    var y = circleR * Mathf.Cos(red);
                //    YS[0].transform.position = transform.position + new Veocter2(x, y);
                //    YS[0].transform.rotation = Quaternion.Euler(0, 0, deg * -1);
                //}
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet Hit!");
            StartCoroutine(OnDamage());
            Destroy(other.gameObject);
        }
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

    IEnumerator OnDamage()
    {
        Debug.Log("OnDamage");
        //enemyHp -= damage;
        //MyMaterial.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        if (enemyHp > 0)
        {
            //MyMaterial.color = new Color(1,1,1);
        }
        
        if ( enemyHp < 0)
        {
            StartCoroutine(Disappearing());
        }
    }

    IEnumerator Disappearing()
    {
        Debug.Log("Disappearing");
        Destroy(this.gameObject);
        yield return null;
    }
}
