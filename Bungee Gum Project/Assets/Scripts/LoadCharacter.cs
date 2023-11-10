using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public Sprite[] characterSprite;

    public int playerNum = 1;

    


    private void Start()
    {
        if(playerNum == 1)
        {
            GetComponent<SpriteRenderer>().sprite = characterSprite[PlayerPrefs.GetInt("seletedCharacter")];
            GetComponent<BoxCollider2D>().offset = new Vector2(PlayerPrefs.GetFloat("seletedOffsetX"), PlayerPrefs.GetFloat("seletedOffsetY"));
            GetComponent<BoxCollider2D>().size = new Vector2(PlayerPrefs.GetFloat("seletedSizeX"), PlayerPrefs.GetFloat("seletedSizeY"));
        }
        else if (playerNum == 2)
        {
            GetComponent<SpriteRenderer>().sprite = characterSprite[PlayerPrefs.GetInt("seletedCharacter2")];
            GetComponent<BoxCollider2D>().offset = new Vector2(PlayerPrefs.GetFloat("seletedOffsetX2"), PlayerPrefs.GetFloat("seletedOffsetY2"));
            GetComponent<BoxCollider2D>().size = new Vector2(PlayerPrefs.GetFloat("seletedSizeX2"), PlayerPrefs.GetFloat("seletedSizeY2"));
        }
        else if (playerNum == 3)
        {
            GetComponent<SpriteRenderer>().sprite = characterSprite[PlayerPrefs.GetInt("seletedCharacter3")];
            GetComponent<BoxCollider2D>().offset = new Vector2(PlayerPrefs.GetFloat("seletedOffsetX3"), PlayerPrefs.GetFloat("seletedOffsetY3"));
            GetComponent<BoxCollider2D>().size = new Vector2(PlayerPrefs.GetFloat("seletedSizeX3"), PlayerPrefs.GetFloat("seletedSizeY3"));
        }
        else if (playerNum == 4)
        {
            GetComponent<SpriteRenderer>().sprite = characterSprite[PlayerPrefs.GetInt("seletedCharacter4")];
            GetComponent<BoxCollider2D>().offset = new Vector2(PlayerPrefs.GetFloat("seletedOffsetX4"), PlayerPrefs.GetFloat("seletedOffsetY4"));
            GetComponent<BoxCollider2D>().size = new Vector2(PlayerPrefs.GetFloat("seletedSizeX4"), PlayerPrefs.GetFloat("seletedSizeY4"));
        }

    }


}
