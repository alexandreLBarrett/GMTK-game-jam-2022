using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDoor : MonoBehaviour
{
    public DiceRotator dice;
    public int diceSide;
    public bool isOpened;

    SpriteRenderer spriteRenderer;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnEnable()
    {
        if (isOpened)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.green;
        }
    }

    public void Open()
    {
        isOpened = true;
        if (spriteRenderer != null)
            spriteRenderer.color = Color.green;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;

        if (isOpened)
            dice.RotateToFace(diceSide);
    }
}
