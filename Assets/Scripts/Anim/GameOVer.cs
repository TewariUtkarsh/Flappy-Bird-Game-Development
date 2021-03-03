using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOVer : MonoBehaviour
{
    public GameManager GameMam;
    public GameObject medal;
    void OnGameOverEnds()
    {
        medal.SetActive(true);

        GameMam.drawScore();
    }
}
