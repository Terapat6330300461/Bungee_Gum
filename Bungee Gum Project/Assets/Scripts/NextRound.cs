using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRound : MonoBehaviour
{
    [SerializeField] string Scene = "";
    public GameObject[] characters;
    public int playerNum = 1;
    public int selectedCharacter = 0;
    public int characterRange = 6;

    public void Update()
    {

       if(PlayerPrefs.GetInt("enterLockRestart") == 0)
        {
            if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)))
            {
                RestartGame();
            }
        }
       else if (PlayerPrefs.GetInt("enterLockNext") == 0)
        {
            if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)))
            {
                NextGame();
            }
        }
        
    }
           
    
    public void NextGame()
    {
        SceneManager.LoadScene(Scene);
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt("scoretext", 0);
        PlayerPrefs.SetInt("scoretext2", 0);
        PlayerPrefs.SetInt("scoretext3", 0);
        PlayerPrefs.SetInt("scoretext4", 0);
        if (playerNum == 1)
        {
            PlayerPrefs.SetInt("seletedCharacter", selectedCharacter);
            PlayerPrefs.SetFloat("seletedOffsetX", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.x);
            PlayerPrefs.SetFloat("seletedOffsetY", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.y);
            PlayerPrefs.SetFloat("seletedSizeX", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.x);
            PlayerPrefs.SetFloat("seletedSizeY", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.y);

            selectedCharacter = Random.Range(0, characterRange);
            PlayerPrefs.SetInt("seletedCharacter2", selectedCharacter);
            PlayerPrefs.SetFloat("seletedOffsetX2", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.x);
            PlayerPrefs.SetFloat("seletedOffsetY2", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.y);
            PlayerPrefs.SetFloat("seletedSizeX2", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.x);
            PlayerPrefs.SetFloat("seletedSizeY2", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.y);
        }

        else if (playerNum == 2)
        {
            PlayerPrefs.SetInt("seletedCharacter2", selectedCharacter);
            PlayerPrefs.SetFloat("seletedOffsetX2", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.x);
            PlayerPrefs.SetFloat("seletedOffsetY2", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.y);
            PlayerPrefs.SetFloat("seletedSizeX2", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.x);
            PlayerPrefs.SetFloat("seletedSizeY2", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.y);
        }
        else if (playerNum == 0)
        {
            selectedCharacter = Random.Range(0, characterRange);
            PlayerPrefs.SetInt("seletedCharacter2", selectedCharacter);
            PlayerPrefs.SetFloat("seletedOffsetX2", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.x);
            PlayerPrefs.SetFloat("seletedOffsetY2", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.y);
            PlayerPrefs.SetFloat("seletedSizeX2", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.x);
            PlayerPrefs.SetFloat("seletedSizeY2", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.y);
        }

        selectedCharacter = Random.Range(0, characterRange);
        PlayerPrefs.SetInt("seletedCharacter3", selectedCharacter);
        PlayerPrefs.SetFloat("seletedOffsetX3", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.x);
        PlayerPrefs.SetFloat("seletedOffsetY3", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.y);
        PlayerPrefs.SetFloat("seletedSizeX3", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.x);
        PlayerPrefs.SetFloat("seletedSizeY3", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.y);


        selectedCharacter = Random.Range(0, characterRange);
        PlayerPrefs.SetInt("seletedCharacter4", selectedCharacter);
        PlayerPrefs.SetFloat("seletedOffsetX4", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.x);
        PlayerPrefs.SetFloat("seletedOffsetY4", characters[selectedCharacter].GetComponent<BoxCollider2D>().offset.y);
        PlayerPrefs.SetFloat("seletedSizeX4", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.x);
        PlayerPrefs.SetFloat("seletedSizeY4", characters[selectedCharacter].GetComponent<BoxCollider2D>().size.y);



        SceneManager.LoadScene(Scene);
    }

}
