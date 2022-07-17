using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Utils : MonoBehaviour
{
    public static Vector3 GetMousePosition(Vector3 targetPlane)
    {
        var worldCamera = Camera.main;
        return worldCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Vector3.Distance(worldCamera.transform.position, targetPlane)));
    }
    
    public class OnPlayerDeathEventArgs : OnStuffDeathEventArgs
    {
    }
    
    public class OnStuffDeathEventArgs : EventArgs
    {
    }
}
