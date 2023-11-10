using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Started());

    }

   

    IEnumerator Started()
    {
        PlayerPrefs.SetInt("enterLockNext", 1);
        PlayerPrefs.SetInt("enterLockRestart", 1);
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseTime) 
            yield return 0;
        Time.timeScale = 1;
    }
}
