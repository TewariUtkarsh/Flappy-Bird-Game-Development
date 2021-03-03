using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Spawner : MonoBehaviour
{
    public GameObject pipe;
    
    public float maxY;
    public float minY;
    public float randY;

    public float max_Time;
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        // Spawn_Pipes();

    }
    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Game_Over == false && GameManager.GamehasStarted == true)
        {
            Timer += Time.deltaTime;

            if (Timer >= max_Time)
            {
                Spawn_Pipes();
                Timer = 0;
            }
        }
    }

    public void Spawn_Pipes()
    {
        randY = Random.Range(maxY, minY);
        GameObject new_Pipe = Instantiate(pipe);

        new_Pipe.transform.position = new Vector2(
            transform.position.x,
            randY);
    }
}
