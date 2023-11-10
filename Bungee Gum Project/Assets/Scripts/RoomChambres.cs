using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChambres : MonoBehaviour

     
{
    public Transform player;
    private float positionX;
    private float positionY;

    private Rigidbody2D body;

    private bool used;

    public AudioSource source;

    public AudioClip chambresSound;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        used = false;

    }


    private void Update()
    {
        if(body.velocity.x != 0)
        {
            StartCoroutine(Destroyed());
        }
        

        



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !used)
        {
            
            
            if (collision.transform.position.x != player.position.x)
            {
                source.PlayOneShot(chambresSound);
                positionX = player.position.x;
                positionY = player.position.y;
                player.position = new Vector2(collision.transform.position.x, collision.transform.position.y);
                collision.transform.position = new Vector2(positionX, positionY);
                used = true;
                transform.localScale = new Vector3(0, 0, 0);
                StartCoroutine(Chambres());
            }
            

        }

    }

    IEnumerator Destroyed()
    {

        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

     IEnumerator Chambres()
    {

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
