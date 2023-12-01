using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementManager : MonoBehaviour
{
    public GameObject sky;
    public GameObject back1;
    public GameObject back2;
    public GameObject back3;

    public GameObject[] skychilds;
    public GameObject[] backchilds1;
    public GameObject[] backchilds2;
    public GameObject[] backchilds3;

    private float skyspeed = -0.001f;
    private float back1Speed = -0.1f;
    private float back2Speed = -0.05f;
    private float back3Speed = -0.01f;

    void Start()
    {
        skychilds = new GameObject[sky.transform.childCount];
        backchilds1 = new GameObject[back1.transform.childCount];
        backchilds2 = new GameObject[back2.transform.childCount];
        backchilds3 = new GameObject[back3.transform.childCount];
        for (int i = 0; i < sky.transform.childCount; i++)
        {
            skychilds[i] = sky.transform.GetChild(i).gameObject;
            skychilds[i].GetComponent<BackgruondObjectMovement>().mySpeed = skyspeed;
        }
        for (int i = 0; i < back1.transform.childCount; i++)
        {
            backchilds1[i] = back1.transform.GetChild(i).gameObject;
            backchilds1[i].GetComponent<BackgruondObjectMovement>().mySpeed = back1Speed;
        }
        for (int i = 0;i < back2.transform.childCount; i++)
        {
            backchilds2[i] = back2.transform.GetChild(i).gameObject;
            backchilds2[i].GetComponent<BackgruondObjectMovement>().mySpeed = back2Speed;
        }
        for (int i = 0; i < back3.transform.childCount; i++)
        {
            backchilds3[i] = back3.transform.GetChild(i).gameObject;
            backchilds3[i].GetComponent<BackgruondObjectMovement>().mySpeed = back3Speed;
        }

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //sky.gameObject.transform.position += new Vector3(0,-0.001f,0);
        //back1.gameObject.transform.position += new Vector3(0, -0.1f, 0);
        //back2.gameObject.transform.position += new Vector3(0, -0.05f, 0);
        //back3.gameObject.transform.position += new Vector3(0, -0.01f, 0);
    }
}
