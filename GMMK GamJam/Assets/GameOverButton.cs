using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    public void OnClick()
    {
        var dm = FindObjectOfType<DiceManager>();
        if (dm != null)
            Destroy(dm.gameObject);

        SceneManager.LoadScene("Menu");
    }
}
