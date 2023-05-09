using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public GameManager gameManager;
    Rigidbody2D rb2D;
    [SerializeField]
    private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;


    public Score score;
    bool touchedGround;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator myanim;

    public ObstacleSpawner obstacleSpawner;


    public AudioSource swim;
    public AudioSource hit;
    public AudioSource point;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        myanim = GetComponent<Animator>();
    }

  
    void Update()
    {
        FishSwim();
    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver==false)
        {
            swim.Play();
            if (GameManager.gameStarted==false)
            {
                rb2D.gravityScale = 3f;
                rb2D.velocity = Vector2.zero;
                rb2D.velocity = new Vector2(rb2D.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            rb2D.velocity = Vector2.zero;
            rb2D.velocity = new Vector2(rb2D.velocity.x, 9f);
        }
    }

    void FishRotation()
    {
        if (rb2D.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rb2D.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        
        if (touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle") && GameManager.gameOver==false)
        {
            score.Scored();
            point.Play();
        }
        else if(collision.CompareTag("Colum"))
        {
            FishDieEffects();
            gameManager.GameOver();
            
        }
     }

    void FishDieEffects()
    {
        hit.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            if(GameManager.gameOver==false)
            {
                FishDieEffects();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        myanim.enabled = false;
    }



}
