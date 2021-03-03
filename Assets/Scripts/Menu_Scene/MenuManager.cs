using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    //References
    public Animator Black_Fade;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        GameManager.Game_Over = false;
    }
    public void OnPlayBTN()
    {
        AudioManager.audiomanager.Play("Transition");
        Black_Fade.SetTrigger("FadeOut");
        //SceneManager.LoadScene("MainScene");
    }
    
    public void OnRateButtonPressed()
    {
    #if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.SigmaGames.Flappy_Bird");
    #endif
    }
}
