using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int high_score;
    Text scoreText;

    //References
    public Text panelScore;
    public Text panel_HighScore;
    public GameObject NewScore;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        score = 0;
        scoreText = GetComponent<Text>();
        panelScore.text = score.ToString();
        scoreText.text = score.ToString();
        high_score = PlayerPrefs.GetInt("HighScore");
        panel_HighScore.text = high_score.ToString();
    
    }

    public int GetScore()
    {
        return score;
    }
    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        //panelScore.text = score.ToString();
        if(score > high_score)
        {
            high_score = score;
            panel_HighScore.text = high_score.ToString();
            PlayerPrefs.SetInt("HighScore", high_score);
            NewScore.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
