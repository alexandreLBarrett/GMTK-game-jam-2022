using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpBar : MonoBehaviour
{
    public float health = 1f;
    public float totalHP = 100f;
    public Image image;
    public bool friendly = false;
    void Update()
    {
        health = Mathf.Clamp01(health);
        image.transform.localScale = new Vector3(health, 1, 1);
        
        if (Input.GetKeyDown("f"))
        {
            TakeDamage(26);
        }
        if (Input.GetKeyDown("h"))
        {
            Heal(30);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage / totalHP;

        if (health < 0)
            GameOver();
    }

    public void Heal(int pts)
    {
        health += pts / totalHP;
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
