using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] items;
    public int maxItem = 2;
    private int randomNum = 0;

    private GameObject item = null;

    private bool respawned = false;




    private void Start()
    {
        randomNum = Random.Range(0, maxItem);
        item  = Instantiate(items[randomNum], transform.position, transform.rotation);
       
        
    }

    private void Update()
    {
        if(item.activeSelf == false && respawned == false)
        {
            respawned = true;
            StartCoroutine(Respawn());
  
        }


    }


    IEnumerator Respawn()
    {
        
        yield return new WaitForSeconds(5);
        randomNum = Random.Range(0, maxItem);
        item.name = items[randomNum].name;
        item.GetComponent<SpriteRenderer>().sprite = items[randomNum].GetComponent<SpriteRenderer>().sprite;
        item.SetActive(true);
        respawned = false;




    }


}
