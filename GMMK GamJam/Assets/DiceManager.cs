using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceManager : MonoBehaviour
{
    //public DiceMap[] dices = new DiceMap[] {
    //    new DiceMap{
    //        faceCount = 6,
    //        assetFilename = "dices/Dice06.obj",
    //        facesNormals = new Vector3[]{
    //            new(-1, 0, 0),
    //            new(0, 0, -1),
    //            new(0, 1, 0),
    //            new(0, -1, 0),
    //            new(0, 0, 1),
    //            new(1, 0, 0)
    //        }
    //    }
    //};

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
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
