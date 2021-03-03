using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    //Refernce
    public Sprite NormalMedal;
    public Sprite BronzeMedal;
    public Sprite SilverMedal;
    public Sprite GoldMedal;


    Image img;
    
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        int GameScore = GameManager.GameScore;
        
        if(GameScore > 0 && GameScore<=5)
        {
            img.sprite = NormalMedal;
        }
        else if(GameScore > 5 && GameScore<=15)
        {
            img.sprite = BronzeMedal;
        }
        else if (GameScore > 15 && GameScore <= 25)
        {
            img.sprite = SilverMedal;
        }
        else if (GameScore > 25 )
        {
            img.sprite = GoldMedal;
        }

    }


}
