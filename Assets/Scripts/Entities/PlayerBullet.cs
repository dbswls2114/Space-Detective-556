using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PlayerBorderBullet")
        {
            Debug.Log("Wall Hit");
            Destroy(gameObject);
        }
    }
}