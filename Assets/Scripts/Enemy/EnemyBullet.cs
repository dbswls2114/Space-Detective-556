using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Palyer Hit");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall Hit");
            Destroy(gameObject);
        }
    }
}
