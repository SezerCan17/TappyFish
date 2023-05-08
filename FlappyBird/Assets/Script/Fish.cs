using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField]
    private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

  
    void Update()
    {
        FishSwim();
        FishRotation();

        
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0))
        {
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

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
