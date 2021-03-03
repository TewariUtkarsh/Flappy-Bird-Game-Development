using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Movement : MonoBehaviour
{
    BoxCollider2D bc;

    public float speed;
    public float ground_width;

    float Pipe_Width;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        
        if(gameObject.CompareTag("Ground"))
        {
            bc = GetComponent<BoxCollider2D>();
            ground_width = bc.size.x;

        }
        else if(gameObject.CompareTag("Pipe"))
        {
            Pipe_Width = GameObject.FindGameObjectWithTag("Pipe1").GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Game_Over == false)
        {
            transform.position = new Vector2(
            transform.position.x - speed * Time.deltaTime,
            transform.position.y);
        }
        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -ground_width)
            {
                transform.position = new Vector2(
                    transform.position.x + 2 * ground_width,
                    transform.position.y);
            }

        }
        else if(gameObject.CompareTag("Pipe"))
        {
            if(transform.position.x < GameManager.bottomLeft.x - Pipe_Width)
            {
                Destroy(gameObject);
            }
        }
    }
}
