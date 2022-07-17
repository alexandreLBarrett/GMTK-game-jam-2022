using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDoor : MonoBehaviour
{
    public DiceRotator dice;
    public int diceSide;
    bool isOpened;
    public bool Opened
    {
        get { return isOpened; }
        set {
            isOpened = value;
            UpdateColor();
        }
    }

    bool isLocked;
    public bool Locked { 
        get { return isLocked; } 
        set { 
            isLocked = value; 
            UpdateColor(); 
        } 
    }

    SpriteRenderer spriteRenderer;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    public void UpdateColor()
    {
        spriteRenderer.color = Color.white;
        if (isOpened)
            spriteRenderer.color = Color.green;
        if (isOpened && isLocked)
            spriteRenderer.color = Color.yellow;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;

        if (isOpened && !isLocked)
            dice.RotateToFace(diceSide);
    }
}
