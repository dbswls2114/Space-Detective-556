using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveCharacterContoller : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    //public event Action<Vector2> OnFireEvent;

    float direction = 0.05f;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    private void Update()
    {
        
    }



    //public void CallMoveEvent(Vector2 direction)
    //{
    //    OnFireEvent?.Invoke(direction);
    //}
}
