using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGot : MonoBehaviour
{
    public Sprite[] itemSprite;
    public int playerNum = 1;

    private void Update()
    {

        if(playerNum == 1)
        {
            gameObject.GetComponent<Image>().sprite = itemSprite[PlayerPrefs.GetInt("itemSprite")];
        }
        else if (playerNum == 2)
        {
            gameObject.GetComponent<Image>().sprite = itemSprite[PlayerPrefs.GetInt("itemSprite2")];
        }


    }
}
