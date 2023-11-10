using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    [SerializeField] private float StartX;
    [SerializeField] private float EndX;
    [SerializeField] private float StartY;
    [SerializeField] private float EndY;
    [SerializeField] private float moveSpeed;
    
    public bool moveUp = false;
    public bool moveDown = false;
    public bool moveRight = false;
    public bool moveLeft = false;

    public bool flipX = false;
    public bool flipY = false;

    public bool isParent = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

{
        if (moveUp)
        {
            if (transform.position.y <= EndY)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            }

            if (transform.position.y >= EndY)
            {
                moveUp = false;
                moveDown = true;
            }


        }

     

        if (moveDown)
        {
            if (transform.position.y >= StartY)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            }
            if (transform.position.y <= StartY)
            {
                moveDown = false;
                moveUp = true;
            }
         
        }


        if (moveRight)
        {
            if (transform.position.x <= EndX)
            {
                if (flipX)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
                }
                transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y );
            }

            if (transform.position.x >= EndX)
            {
                moveRight = false;
                moveLeft = true;
            }


        }



        if (moveLeft)
        {
            if (transform.position.x >= StartX)
            {
                if (flipX)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
                }
                transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y );
            }
            if (transform.position.x <= StartX)
            {
                moveLeft = false;
                moveRight = true;
            }

        }



    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (isParent)
        {
            if (collison.gameObject.tag == "Player")
            {

                collison.gameObject.transform.SetParent(transform);

                
            }
        }
        

    }


    private void OnCollisionExit2D(Collision2D collison)
    {
        if (isParent)
        {
            if (collison.gameObject.tag == "Player")
            {

                collison.gameObject.transform.SetParent(null);
            }

        }
            
    }
}
