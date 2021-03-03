using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    //Reference
    Image img;
    public Sprite playSprite;
    public Sprite pauseSprite;
    private AudioSource Audio;
    public void Start()
    {
        Application.targetFrameRate = 60;
        img = GetComponent<Image>();
        Audio = GetComponent<AudioSource>();
    }
    public void ToPause()
    {
        if(GameManager.Game_Pause == false)
        {
            Time.timeScale = 0; // Freeze the Game 
            Audio.Stop();
            img.sprite = playSprite;
            GameManager.Game_Pause = true;
        }
        else
        {
            Time.timeScale = 1; // Run the game at normal speed
            Audio.Play();
            img.sprite = pauseSprite;
            GameManager.Game_Pause = false;
            
        }
    }
}
