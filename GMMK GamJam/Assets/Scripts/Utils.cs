using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 GetMousePosition()
    {
        var worldCamera = Camera.main;
        return worldCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
