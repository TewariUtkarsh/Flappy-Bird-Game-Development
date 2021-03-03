using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Black_Fade : MonoBehaviour
{
   void ONBlackFadeEnds()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("MainScene");
        }
        else if(SceneManager.GetActiveScene().name == "MainScene")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
