using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgruondObjectMovement : MonoBehaviour
{
    public float mySpeed = 0f;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Move(mySpeed);
    }

    void Move(float _speed)
    {
        this.gameObject.transform.position += new Vector3(0, _speed, 0);
    }
}
