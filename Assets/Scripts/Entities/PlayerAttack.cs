using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private PlayerCharacterContoller _contoller;
    [SerializeField] private Transform projectileSpawnPosition;

    public GameObject bulletA;

    private void Awake()
    {
        _contoller = GetComponent<PlayerCharacterContoller>();
    }
    void Start()
    {
        _contoller.OnAttackEvent += OnShoot;
    }
    private void OnShoot()
    {
        Createprojectile();
    }
    private void Createprojectile()
    {
        GameObject bullet = Instantiate(bulletA, projectileSpawnPosition.position, Quaternion.identity);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
