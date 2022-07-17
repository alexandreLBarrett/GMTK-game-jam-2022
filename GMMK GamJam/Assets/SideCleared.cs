using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideCleared : MonoBehaviour
{
    float scale = 0;
    float scaleRate = 0.7f;


    public CanvasScaler scaler;

    public void Show()
    {
        scale = 1f;
        scaler.scaleFactor = 1f;
        gameObject.SetActive(true);
    }

    public void Update()
    {
        if (scale >= 0.2f)
        {
            scale -= scaleRate * Time.deltaTime;
            scaler.scaleFactor -= scaleRate * Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
