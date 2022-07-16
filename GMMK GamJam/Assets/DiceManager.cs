using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadDice(int diceId)
    {
        string sceneFilename = "Assets/Scenes/D" + diceId + ".unity";

        if (System.IO.File.Exists(sceneFilename))
        {
            SceneManager.LoadScene(sceneFilename);
        }
        else
        {
            Debug.LogError(sceneFilename + " does not exist");
        }
    }
}
