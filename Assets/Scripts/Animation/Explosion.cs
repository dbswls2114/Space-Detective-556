using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>(); 
    }

    private void OnEnable()
    {
        Invoke("Disable", 2f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    // 적 처치시 폭발이펙트 적 크기별로 나눔
    public void StartExplosion(string target)
    {
        anim.SetTrigger("OnExplosion");

        switch (target)
        {
            case "S":
                transform.localScale = Vector3.one * 0.7f;
                break;
            case "M":
            case "P":
                transform.localScale = Vector3.one * 1f;
                break;
            case "L":
                transform.localScale = Vector3.one * 2f;
                break;
            case "B":
                transform.localScale = Vector3.one * 3f;
                break;
        }

    }
}


//GameManager스크립트에 생성  적 위치에 따라 폭발하는 함수
    
//public void CallExplosion(Vector3 pos, string type)
//{
//    GameObject explosion = objectManager.Makeobj("Explosion");
//    Explosion explosionLogic = explosion.GetComponent<Explosion>();

//    explosion.transform.position = pos;
//    explosionLogic.StartExplosion(type);
//}

//gameManager.CallExplosion(Transform.position, "P"); 플레이어와 적이 맞아 죽었을때 위치에다가 호출해야됨
//gameManager.CallExplosion(Transform.position, enemyName);




