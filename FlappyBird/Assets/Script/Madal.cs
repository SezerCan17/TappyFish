using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Madal : MonoBehaviour
{
    public Sprite metalMedal, bronzeMedal, silverMedal, goldMedal;
    Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        int gameScore = GameManager.gameScore;

        if(gameScore > 0 && gameScore <=5)
        {
            img.sprite = metalMedal;
        }
        else if(gameScore > 5 && gameScore <=10) 
        {
            img.sprite = bronzeMedal;
        }
        else if (gameScore > 10 && gameScore <= 15)
        {
            img.sprite = silverMedal;
        }
        else if (gameScore > 20)
        {
            img.sprite = goldMedal;
        }
    }
}
