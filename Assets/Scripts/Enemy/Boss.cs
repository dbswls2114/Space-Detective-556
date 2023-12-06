using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public enum PatternType
    {
        PatternA,
        PatternB,
        PatternC
    };
    PatternType pattern;

    public float enemyHp;

    public Transform bulletPos;
    public GameObject bulletObj;

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    Animator anim;
    CircleCollider2D circleCollider;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    void Start()
    {
        StartCoroutine(PatternA());

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Pattern()
    {
        switch (pattern)
        {
            case PatternType.PatternA:
                break;
            case PatternType.PatternB:
                break;
            case PatternType.PatternC:
                break;
        }
    }
    IEnumerator PatternA()
    {
        int speed = 100;
        int bullets = 30;
        float angle = 360 / bullets;

        for (int i = 0; i < bullets; i++)
        {
            bulletObj = Instantiate(bulletObj, bulletPos.position, Quaternion.identity);

            bulletObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / bullets), speed * Mathf.Sin(Mathf.PI * i * 2 / bullets)));
            bulletObj.transform.Rotate(new Vector3(0f, 0f, 360 * i / bullets - 90));
        }
        yield return new WaitForSeconds(4f);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            OnHit(1);
        }
    }
    void OnHit(int damage)
    {
        enemyHp -= damage;
        if (enemyHp <= 0)
        {
            anim.SetTrigger("OnExplosion");
            Destroy(this.gameObject, 0.5f);
            circleCollider.enabled = false;
        }
    }
}
