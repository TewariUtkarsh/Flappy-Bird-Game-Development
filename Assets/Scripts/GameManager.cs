using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //References
    public GameObject gameOverCanvas;
    public GameObject score;
    public GameObject GetReadyImg;
    public GameObject PauseBTN;
    public Animator Black_Fade;
    public Text panelScore;

    public static Vector2 bottomLeft;

    //Game States
    public static bool Game_Over;
    public static bool GamehasStarted;
    public static bool Game_Pause;
    public static int GameScore;
    int DrawScore;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Game_Over = false;
        GamehasStarted = false;
        Game_Pause = false;
    }
    public void GameHasStarted()
    {
        GamehasStarted = true;
        score.SetActive(true);
        GetReadyImg.SetActive(false);
        PauseBTN.SetActive(true);
    }
    public void GameOver()
    {
        Game_Over = true;
        GameScore = score.GetComponent<Score>().GetScore();
        score.SetActive(false);
        Invoke("ActivateGameOver", 1);
        PauseBTN.SetActive(false);
    }

    void ActivateGameOver()
    {
        gameOverCanvas.SetActive(true);
        AudioManager.audiomanager.Play("Die");
    }
    public void OKButton()
    {
        AudioManager.audiomanager.Play("Transition");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ONMenuButton()
    {
        AudioManager.audiomanager.Play("Transition");
        Black_Fade.SetTrigger("FadeOut");
        SceneManager.LoadScene("Menu");
    }

    public void drawScore()
    {
        if(DrawScore <= GameScore)
        {
            panelScore.text = DrawScore.ToString();
            DrawScore++;
            Invoke("drawScore", 0.05f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
