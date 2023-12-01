using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{

    public float speed;
    // Update is called once per frame
    public int startIdx;
    public int endIdx;
    public Transform[] sprites;

    float viewHeight;

    private void Awake(){
        viewHeight = Camera.main.orthographicSize * 2;
    }
    void Update()
    {
        Vector2 curPos = transform.position;;
        Vector2 nextPos = Vector2.down  * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

        if(sprites[endIdx].position.y < viewHeight*(-1)){
            Vector2 backSpritePos = sprites[startIdx].localPosition;
            Vector2 frontSpritePos = sprites[endIdx].localPosition;
            sprites[endIdx].transform.localPosition = backSpritePos + Vector2.up*10;
       
            int startIdxTmp = startIdx;
            startIdx = endIdx;
            endIdx = startIdxTmp--;

        }
    }
}
