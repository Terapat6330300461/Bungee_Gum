using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] string Scene = "";
    [SerializeField] string Scene2 = "";
    [SerializeField] string Scene3 = "";
    public GameObject[] characters; 
    public int playerNum = 1;
    public int selectedCharacter = 0;
    public int selectedScene = 0;
    public int characterRange = 6;
    public int sceneRange = 3;
    public bool once = true;
    public GameObject nametext;

    private void Start()
    {
        nametext.GetComponent<Text>().text = characters[selectedCharacter].name;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.D))|| (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            NextCharacter();
        }
        else if ((Input.GetKeyDown(KeyCode.A))||(Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            PreviousCharacter();
        }
        if ((Input.GetKeyDown(KeyCode.Space))|| (Input.GetKeyDown(KeyCode.Return)) && once == true)
        {
            once = false;
            StartGame();
        }
    }
    public void NextCharacter()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)) )
        {
            
        }
        else
        {
            characters[selectedCharacter].SetActive(false);
            selectedCharacter = (selectedCharacter + 1) % characters.Length;
            characters[selectedCharacter].SetActive(true);
            nametext.GetComponent<Text>().text = characters[selectedCharacter].name;
        }

    }
    public void PreviousCharacter()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)))
        {

        }
        else
        {
            characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("scoretext", PlayerPrefs.GetInt("scoretext") + 1);
        nametext.GetComponent<Text>().text = characters[selectedCharacter].name;
        }
    }

    public void StartGame()
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


        selectedScene = Random.Range(0, 3);
        if(selectedScene == 0)
        {
            SceneManager.LoadScene(Scene);
        }
        else if (selectedScene == 1)
        {
            SceneManager.LoadScene(Scene2);
        }
        else if (selectedScene == 2)
        {
            SceneManager.LoadScene(Scene3);
        }
        
    }

}




