using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string Scene = "";
    public bool canPress = false;
    public bool canSelectedMode = false;
    public int mode = 0;
    
    public int selectedMode = 0;

    public void Start()
    {
        
        PlayerPrefs.SetInt("selectedMode", 1);
        selectedMode = PlayerPrefs.GetInt("selectedMode");
    }

    public void Update()
    {
       
        if (canPress)
        {
            if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)))
            {
                NextScene();
            }
        } 
        
        
        else if (canSelectedMode)
        {
          
            if (PlayerPrefs.GetInt("selectedMode") == mode)
            {
                
                if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)))
                {
                    NextScene();
                }
            }
            if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                if(selectedMode == 2)
                {
                    selectedMode = 1;
                }
                else if(selectedMode == 1)
                {
                    selectedMode = 2;
                }
                
                PlayerPrefs.SetInt("selectedMode", selectedMode);
                
            }
            if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
            {
                if (selectedMode == 2)
                {
                    selectedMode = 1;
                }
                else if (selectedMode == 1)
                {
                    selectedMode = 2;
                }
                PlayerPrefs.SetInt("selectedMode", selectedMode);

            }


            if(selectedMode != PlayerPrefs.GetInt("selectedMode"))
            {
                if(selectedMode == 1)
                {
                    selectedMode = 2;
                }
                else if(selectedMode == 2)
                {
                    selectedMode = 1;
                }
            }




        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(Scene);
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnButtonCursorEnter()
    {
        if (canSelectedMode)
        { 
            if (mode == 1)
            {
                PlayerPrefs.SetInt("selectedMode", 1);
                selectedMode = 1;

            }
            if (mode == 2)
            {
                PlayerPrefs.SetInt("selectedMode", 2);
                selectedMode = 2;

            }
        
        
        }

            

    }


    


}



    

