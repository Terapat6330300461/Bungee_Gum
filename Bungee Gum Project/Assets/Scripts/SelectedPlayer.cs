using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPlayer : MonoBehaviour
{
    public GameObject Makima01;
    public GameObject Makima02;
    void Start()
    {
        Makima01.SetActive(true);
        Makima02.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("selectedMode") == 1)
        {
            Makima01.SetActive(true);
            Makima02.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selectedMode") == 2)
        {
            Makima01.SetActive(false);
            Makima02.SetActive(true);
        }
    }
}
