using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeTwoOne : MonoBehaviour
{
    public GameObject Ready;
    public GameObject Go;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;


    void Start()
    {
        Player1.GetComponent<Rigidbody2D>().gravityScale = 0;
        Player2.GetComponent<Rigidbody2D>().gravityScale = 0;
        Player3.GetComponent<Rigidbody2D>().gravityScale = 0;
        Player4.GetComponent<Rigidbody2D>().gravityScale = 0;
        Go.SetActive(false);
        StartCoroutine(Started());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Started()
    {
        PlayerPrefs.SetInt("canMove", 0);
        PlayerPrefs.SetInt("canMove2", 0);
        PlayerPrefs.SetInt("canMove3", 0);
        PlayerPrefs.SetInt("canMove4", 0);
        yield return new WaitForSeconds(1);
        Ready.SetActive(false);
        Go.SetActive(true);
        PlayerPrefs.SetInt("canMove", 1);
        PlayerPrefs.SetInt("canMove2", 1);
        PlayerPrefs.SetInt("canMove3", 1);
        PlayerPrefs.SetInt("canMove4", 1);
        Player1.GetComponent<Rigidbody2D>().gravityScale = 1;
        Player2.GetComponent<Rigidbody2D>().gravityScale = 1;
        Player3.GetComponent<Rigidbody2D>().gravityScale = 1;
        Player4.GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitForSeconds(2);
       
        Go.SetActive(false);
      
    }
}
