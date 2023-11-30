using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputContoller : DetectiveCharacterContoller
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        Vector2 LookInput = value.Get<Vector2>().normalized;
        CallMoveEvent(LookInput);
    }

}
