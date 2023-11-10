using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject icon;
    public GameObject icon5;
    public GameObject icream;
    public GameObject player;

    private float minMapPosition;
    private float maxMapPosition;
    private float yMapPosition;

    public float minPlayerPosition = 14f;
    public float maxPlayerPosition = 485f;

    private float mapDistance;
    private float playerDistance;

    private float iconPosition;


    void Start()
    {
        yMapPosition = icon.transform.position.y;
        minMapPosition = icon5.transform.position.x;
        maxMapPosition = icream.transform.position.x;
        mapDistance = maxMapPosition - minMapPosition;
        playerDistance = maxPlayerPosition - minPlayerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(yMapPosition != icon.transform.position.y)
        {
            yMapPosition = icon.transform.position.y;
            minMapPosition = icon5.transform.position.x;
            maxMapPosition = icream.transform.position.x;
            mapDistance = maxMapPosition - minMapPosition;
            playerDistance = maxPlayerPosition - minPlayerPosition;
            icon.transform.position = new Vector2(minMapPosition, icon.transform.position.y);
        }
        if(yMapPosition == icon.transform.position.y)
        {
            if (player.transform.position.x <= minPlayerPosition)
            {
                icon.transform.position = new Vector2(minMapPosition, icon.transform.position.y);
            }
            else if (player.transform.position.x >= maxPlayerPosition)
            {
                icon.transform.position = new Vector2(maxMapPosition, icon.transform.position.y);
            }
            else
            {
                iconPosition = minMapPosition + (((player.transform.position.x - minPlayerPosition)-1) * (mapDistance / playerDistance));
                icon.transform.position = new Vector2(iconPosition, icon.transform.position.y);
            }
        }
        
        
        
    }

  

}
