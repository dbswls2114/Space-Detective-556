using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScripts : MonoBehaviour
{
    public GameObject sky;
    public GameObject back1;
    public GameObject back2;
    public GameObject back3;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        sky.gameObject.transform.position += new Vector3(0,-0.001f,0);
        back1.gameObject.transform.position += new Vector3(0, -0.1f, 0);
        back2.gameObject.transform.position += new Vector3(0, -0.05f, 0);
        back3.gameObject.transform.position += new Vector3(0, -0.01f, 0);
    }
}
