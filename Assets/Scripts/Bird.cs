using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //reference
    public Score sc;
    public GameManager GM;
    public Sprite Birdie;
    public Pipe_Spawner pipspawn;
    public Animator bird_anim;
    public Animator GetReady;
    public Animator Hit;
    public Animator Cam;
    public AudioClip menu;
    private AudioSource Audio;

    SpriteRenderer sp;
    Animator anim;

    Rigidbody2D rb;

    public float speed;
    int angle;
    int max_angle = 20;
    int min_angle = -90;

    bool touchG = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb.gravityScale = 0;
        Audio = GetComponent<AudioSource>();
        
    }


    //void OnMusClick()
    //{
    //    if (Input.GetMouseButtonDown(0) && GameManager.Game_Over == false && GameManager.Game_Pause == false)
    //    {
    //        Audio = GetComponent<AudioSource>();
    //        Audio.clip = menu;
    //        Audio.loop = true;
    //        Audio.Play();
    //    }
    //    else if(GameManager.Game_Pause == true || GameManager.Game_Over == true)
    //    {
    //        Audio.Stop();
    //    }
        
    //}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && GameManager.Game_Over==false && GameManager.Game_Pause == false)
        {
            if(GameManager.GamehasStarted == false)
            {
                rb.gravityScale = 0.8f;
                bird_anim.enabled = false;
                flap();
                // Pipe Spawner 
                //Set the Trigger for the GetReady Anim
                GetReady.SetTrigger("Fade_Out");

            }
            else
            {
                flap();
            }
        }
        if(GameManager.Game_Pause == true)
        {
            Audio.Stop();
        }
        Bird_Rotation();
    }

    public void OnGetReadyFinishes()
    {
        GM.GameHasStarted();
        pipspawn.Spawn_Pipes();
        Audio.Play();
    }
    void flap()
    {
        AudioManager.audiomanager.Play("Wing");
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(rb.velocity.x, speed);

    }
    void Bird_Rotation()
    {
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 0.8f;
            if (angle <= max_angle)
            {
                angle += 4;
            }
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = 0.6f;

            if (rb.velocity.y < -1.3f)
            {
                if (angle > min_angle)
                {
                    angle -= 3;
                }
            }
        }

        if(touchG == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.Game_Over == false)
        {
            if (collision.CompareTag("Pipe"))
            {
                //print("We have Scored");
                AudioManager.audiomanager.Play("Point");
                sc.Scored();
            }
            else if (collision.CompareTag("Pipe1"))
            {
                BirdieEffect();
                //Game Over
                GM.GameOver();
            }
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.Game_Over == false)
            {
                BirdieEffect();
                GM.GameOver();
                GameOver();

            }
            else
            {
                GameOver();
            }
        }
    }

    void BirdieEffect()
    {
        AudioManager.audiomanager.Play("Hit");
        Hit.SetTrigger("Hit");
        Cam.SetTrigger("Shake");
    }
    void GameOver()
    {
        touchG = true;
        anim.enabled = false;
        sp.sprite = Birdie;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
