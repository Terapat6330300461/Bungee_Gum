using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform obj;
    public float deltaX;
    public float deltaY;
    public float rotatedZ = 0f;
    public bool canFlip = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canFlip)
        {
            if(obj.rotation.y == 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 0, rotatedZ);
                transform.position = new Vector3(obj.position.x + deltaX, obj.position.y + deltaY, transform.position.z);
            }

            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 180, rotatedZ);
                transform.position = new Vector3(obj.position.x - deltaX, obj.position.y + deltaY, transform.position.z);
            }
        }
        else
        {
            transform.position = new Vector3(obj.position.x + deltaX, obj.position.y + deltaY, transform.position.z);
        }
        

    }
}
