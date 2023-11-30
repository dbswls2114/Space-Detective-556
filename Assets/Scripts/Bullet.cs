using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag =="Wall")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 2);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2);
    }
}
