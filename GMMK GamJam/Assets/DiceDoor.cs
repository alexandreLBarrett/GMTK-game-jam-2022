using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDoor : MonoBehaviour
{
    public DiceRotator dice;
    public int diceSide;
    public bool isOpened;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpened)
            dice.RotateToFace(diceSide);
    }
}
