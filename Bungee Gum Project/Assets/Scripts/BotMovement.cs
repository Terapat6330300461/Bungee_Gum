using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float startX;
    [SerializeField] private float startY;

    [SerializeField] private int startRange;
    [SerializeField] private int endRange;

    [SerializeField] private int midRange;

    public GameObject canvas0;
    public GameObject canvas;
    public GameObject scoretext;



    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;

    public GameObject World;

    public int playerNum = 2;

    public int ranking = 0;

    private Rigidbody2D body;

    private bool Grounded;
    private int randomNumber;
    private int go;
    private bool canJump;

    private float dukdik = 0;
    private bool step = true;

    public AudioSource source2;
    public AudioClip roomSound;
    public AudioClip hollowPurpleSound;
    public AudioClip seedModeSound;
    public AudioClip timeStopSound;
    public AudioClip timeResumeSound;
    public AudioClip kiBlastSound;


    private bool gotItem = false;
    private bool itemDevilFruit = false;
    private bool itemSixEyes = false;
    private bool itemSeed = false;
    private int seedMode = 1;
    private bool itemStand = false;
    private bool itemGhost = false;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public float bulletSpeed = 10f;

    private bool charging = false;

    private bool delayZawarudo = false;

    private void Start()
    {
        gotItem = false;
        itemDevilFruit = false;
        itemSixEyes = false;
        itemSeed = false;
        itemGhost = false;
        canvas0.SetActive(false);
        canvas.SetActive(false);
        if(playerNum == 2)
        {
            scoretext.GetComponent<Text>().text = PlayerPrefs.GetInt("scoretext2").ToString("F0");
        }
        if(playerNum == 3)
        {
            scoretext.GetComponent<Text>().text = PlayerPrefs.GetInt("scoretext3").ToString("F0");
        }
        if(playerNum == 4)
        {
            scoretext.GetComponent<Text>().text = PlayerPrefs.GetInt("scoretext4").ToString("F0");
        }
        


        charging = false;
        delayZawarudo = false;
    }



    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        go = 1;
        canJump = true;
    }

    private void Update()
    {
        if((playerNum == 2 && PlayerPrefs.GetInt("canMove2") == 1 && charging == false) || (playerNum == 3 && PlayerPrefs.GetInt("canMove3") == 1 && charging == false) || (playerNum == 4 && PlayerPrefs.GetInt("canMove4") == 1 && charging == false)) {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z + dukdik);
            if (dukdik >= 4)
            {
                step = false;
            }
            else if (dukdik <= -4)
            {
                step = true;
            }

            if (step)
            {
                dukdik += 100 * Time.deltaTime;
            }
            else if (!step)
            {
                dukdik -= 100 * Time.deltaTime;
            }
            body.velocity = new Vector2(speed * seedMode * 100 *  Time.fixedDeltaTime * go, body.velocity.y);
        

            if ( Grounded && randomNumber < midRange && canJump )
            {
                body.velocity = new Vector2(body.velocity.x, speed * 100 * 2 * Time.fixedDeltaTime);
                Grounded = false;
            } 
        }

        if (gotItem)
        {
            if (itemSeed)
            {
                source2.PlayOneShot(seedModeSound);
                seedMode = 2;
                StartCoroutine(SeedMode());
                itemSeed = false;
                gotItem = false;

            }
            if (playerNum == 2)
            {
                if(GetComponent<SpriteRenderer>().sortingOrder !=101){
                    if (itemStand && delayZawarudo == false)
                    {

                        StartCoroutine(Zawarudo());
                        itemStand = false;
                        gotItem = false;

                    }

                }
            }
            else if (playerNum == 3)
            {
                if (GetComponent<SpriteRenderer>().sortingOrder != 101)
                {
                    if (itemStand)
                    {

                        StartCoroutine(Zawarudo());
                        itemStand = false;
                        gotItem = false;

                    }

                }
            }
            else if (playerNum == 4)
            {
                if (GetComponent<SpriteRenderer>().sortingOrder != 101)
                {
                    if (itemStand)
                    {

                        StartCoroutine(Zawarudo());
                        itemStand = false;
                        gotItem = false;

                    }

                }
            }
            
            
        }

            randomNumber = Random.Range(startRange, endRange);

       


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Ball")
        {

            Grounded = true;

        }
        if (collision.gameObject.tag == "Platform")
        {

            transform.position = new Vector2(startX, startY);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {

            transform.position = new Vector2(startX, startY);

        }

        if (collision.CompareTag("CheckPoint"))
        {
            
            startX = collision.gameObject.transform.position.x - ranking * 2;
            startY = collision.gameObject.transform.position.y;


        }

        if (collision.CompareTag("Goal"))
        {
            PlayerPrefs.SetInt("Camera1", playerNum);
            PlayerPrefs.SetInt("Camera2", playerNum);
            if (playerNum == 2)
            {
            PlayerPrefs.SetInt("scoretext2", PlayerPrefs.GetInt("scoretext2") + 1);
            scoretext.GetComponent<Text>().text = PlayerPrefs.GetInt("scoretext2").ToString("F0");
                if (PlayerPrefs.GetInt("scoretext2") >= 2)
                {
                    canvas.SetActive(true);
                    PlayerPrefs.SetInt("enterLockRestart", 0);
                }
                else
                {
                    canvas0.SetActive(true);
                    PlayerPrefs.SetInt("enterLockNext", 0);
                }
            }

            else if (playerNum == 3)
            {
                PlayerPrefs.SetInt("scoretext3", PlayerPrefs.GetInt("scoretext3") + 1);
                scoretext.GetComponent<Text>().text = PlayerPrefs.GetInt("scoretext3").ToString("F0");
                if (PlayerPrefs.GetInt("scoretext3") >= 2)
                {
                    canvas.SetActive(true);
                    PlayerPrefs.SetInt("enterLockRestart", 0);
                }
                else
                {
                    canvas0.SetActive(true);
                    PlayerPrefs.SetInt("enterLockNext", 0);
                }
            }

            else if (playerNum == 4)
            {
                PlayerPrefs.SetInt("scoretext4", PlayerPrefs.GetInt("scoretext4") + 1);
                scoretext.GetComponent<Text>().text = PlayerPrefs.GetInt("scoretext4").ToString("F0");
                if (PlayerPrefs.GetInt("scoretext4") >= 2)
                {
                    canvas.SetActive(true);
                    PlayerPrefs.SetInt("enterLockRestart", 0);
                }
                else
                {
                    canvas0.SetActive(true);
                    PlayerPrefs.SetInt("enterLockNext", 0);
                }
            }


            
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Head"))
        {

            if (collision.gameObject.name != "Player 2 Head" && playerNum == 2)
            {
                Grounded = true;
            }
            else if (collision.gameObject.name != "Player 3 Head" && playerNum == 3)
            {
                Grounded = true;
            }

            else if (collision.gameObject.name != "Player 4 Head" && playerNum == 4)
            {
                Grounded = true;
            }



        }

        if (collision.CompareTag("BotDetectGreen"))
        {
           

            
                body.velocity = new Vector2(body.velocity.x, speed * 100 * 2 * Time.fixedDeltaTime);
               
            

        }


        if (collision.CompareTag("BotDetectPurple"))
        {



            if (gotItem)
            {
                if (itemDevilFruit)
                {
                    source2.PlayOneShot(roomSound);
                    var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
                    itemDevilFruit = false;
                }
                if (itemSixEyes)
                {
                    body.velocity = new Vector2(body.velocity.x, 0);
                    body.gravityScale = 0;
                    charging = true;
                    source2.PlayOneShot(hollowPurpleSound);
                    StartCoroutine(HollowPurple());
                    itemSixEyes = false;
                }
                
                if (itemGhost)
                {


                    source2.PlayOneShot(kiBlastSound);
                    if (transform.rotation.y != 0)
                    {
                        var ghostPosition = new Vector2(bulletSpawnPoint.position.x - 2, bulletSpawnPoint.position.y);
                        var bullet = Instantiate(bulletPrefab3, ghostPosition, bulletSpawnPoint.rotation);
                        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * (bulletSpeed + 5);
                    }
                    else
                    {
                        var ghostPosition = new Vector2(bulletSpawnPoint.position.x + 2, bulletSpawnPoint.position.y);
                        var bullet = Instantiate(bulletPrefab3, ghostPosition, bulletSpawnPoint.rotation);
                        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * (bulletSpeed + 5);
                    }

                    itemGhost = false;

                }

                gotItem = false;
            }



        }


        if (collision.CompareTag("Item"))
        {

            if (gotItem == false)
            {
                if (collision.gameObject.name == "Devil Fruit" || collision.gameObject.name == "Devil Fruit(Clone)")
                {

                    itemDevilFruit = true;
                }
                else if (collision.gameObject.name == "Six Eyes" || collision.gameObject.name == "Six Eyes(Clone)")
                {
                    
                    itemSixEyes = true;
                }
                else if (collision.gameObject.name == "Seed" || collision.gameObject.name == "Seed(Clone)")
                {
                    
                    itemSeed = true;
                }
                else if (collision.gameObject.name == "Stand" || collision.gameObject.name == "Stand(Clone)")
                {
                    
                    itemStand = true;
                }
                else if (collision.gameObject.name == "Ghost" || collision.gameObject.name == "Ghost(Clone)")
                {

                    
                    itemGhost = true;
                }
                collision.gameObject.SetActive(false);
                gotItem = true;
            }



        }


        if (collision.CompareTag("SlowDown"))
        {

            speed = 1;


        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        


        

        if (collision.CompareTag("BotDetectOrange"))
        {

            canJump = false;

        }

        if (collision.CompareTag("BotDetectRed"))
        {

            go = 0;


        }

        


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Head"))
        {

            Grounded = false;

        }


        if (collision.CompareTag("BotDetectRed"))
        {

            go = 1;


        }


        if (collision.CompareTag("BotDetectOrange"))
        {

            canJump = true;


        }


        if (collision.CompareTag("SlowDown"))
        {

            speed = 2;


        }





    }





    IEnumerator HollowPurple()
    {

        yield return new WaitForSeconds(2);
        charging = false;

        body.gravityScale = 1;
        if (transform.rotation.y != 0)
        {
            var purplePosition = new Vector2(bulletSpawnPoint.position.x - 4, bulletSpawnPoint.position.y);
            var bullet = Instantiate(bulletPrefab2, purplePosition, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * (bulletSpeed + 5);
        }
        else
        {
            var purplePosition = new Vector2(bulletSpawnPoint.position.x + 4, bulletSpawnPoint.position.y);
            var bullet = Instantiate(bulletPrefab2, purplePosition, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * (bulletSpeed + 5);
        }




    }
    IEnumerator SeedMode()
    {

        yield return new WaitForSeconds(5);
        seedMode = 1;
    }

    IEnumerator Zawarudo()
    {

        delayZawarudo = true;
        source2.PlayOneShot(timeStopSound);
        yield return new WaitForSeconds(2);
        delayZawarudo = false;
        if (playerNum == 2)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 101;
            obj1.GetComponent<SpriteRenderer>().sortingOrder = 10;
            obj3.GetComponent<SpriteRenderer>().sortingOrder = 10;
            obj4.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
        else if (playerNum == 3)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 101;
            obj1.GetComponent<SpriteRenderer>().sortingOrder = 10;
            obj2.GetComponent<SpriteRenderer>().sortingOrder = 10;
            obj4.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
        else if (playerNum == 4)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 101;
            obj1.GetComponent<SpriteRenderer>().sortingOrder = 10;
            obj2.GetComponent<SpriteRenderer>().sortingOrder = 10;
            obj3.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
        World.SetActive(true);
        if (playerNum == 2)
        {
       
            body.velocity = new Vector2(body.velocity.x, body.velocity.y);
            body.gravityScale = 1;
            obj1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            obj1.GetComponent<Rigidbody2D>().gravityScale = 0;
            obj3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            obj3.GetComponent<Rigidbody2D>().gravityScale = 0;
            obj4.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            obj4.GetComponent<Rigidbody2D>().gravityScale = 0;
            PlayerPrefs.SetInt("canMove", 0);
            PlayerPrefs.SetInt("canMove2", 1);
            PlayerPrefs.SetInt("canMove3", 0);
            PlayerPrefs.SetInt("canMove4", 0);
            yield return new WaitForSeconds(3);
            if (PlayerPrefs.GetInt("canMove2") == 1)
            {
                source2.PlayOneShot(timeResumeSound);
            }
            yield return new WaitForSeconds(2);
            if (PlayerPrefs.GetInt("canMove2") == 1)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 10;
                obj1.GetComponent<SpriteRenderer>().sortingOrder = 10;
                obj3.GetComponent<SpriteRenderer>().sortingOrder = 10;
                obj4.GetComponent<SpriteRenderer>().sortingOrder = 10;
                body.gravityScale = 1;
                PlayerPrefs.SetInt("canMove2", 1);
                obj1.GetComponent<Rigidbody2D>().gravityScale = 1;
                PlayerPrefs.SetInt("canMove", 1);
                obj3.GetComponent<Rigidbody2D>().gravityScale = 1;
                PlayerPrefs.SetInt("canMove3", 1);
                obj4.GetComponent<Rigidbody2D>().gravityScale = 1;
                PlayerPrefs.SetInt("canMove4", 1);
                World.SetActive(false);
            }
            
        }
        else if(playerNum == 3)
        {
        
            body.velocity = new Vector2(body.velocity.x, body.velocity.y);
            body.gravityScale = 1;
            obj1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            obj1.GetComponent<Rigidbody2D>().gravityScale = 0;
            obj2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            obj2.GetComponent<Rigidbody2D>().gravityScale = 0;
            obj4.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            obj4.GetComponent<Rigidbody2D>().gravityScale = 0;
            PlayerPrefs.SetInt("canMove", 0);
            PlayerPrefs.SetInt("canMove2", 0);
            PlayerPrefs.SetInt("canMove3", 1);
            PlayerPrefs.SetInt("canMove4", 0);
            yield return new WaitForSeconds(5);
            if (PlayerPrefs.GetInt("canMove3") == 1)
            {
                source2.PlayOneShot(timeResumeSound);
            }
            yield return new WaitForSeconds(2);
            if (PlayerPrefs.GetInt("canMove3") == 1)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 10;
                obj1.GetComponent<SpriteRenderer>().sortingOrder = 10;
                obj2.GetComponent<SpriteRenderer>().sortingOrder = 10;
                obj4.GetComponent<SpriteRenderer>().sortingOrder = 10;
                body.gravityScale = 1;
                PlayerPrefs.SetInt("canMove3", 1);
                obj1.GetComponent<Rigidbody2D>().gravityScale = 1;
                PlayerPrefs.SetInt("canMove", 1);
                obj2.GetComponent<Rigidbody2D>().gravityScale = 1;
                PlayerPrefs.SetInt("canMove2", 1);
                obj4.GetComponent<Rigidbody2D>().gravityScale = 1;
                PlayerPrefs.SetInt("canMove4", 1);
                World.SetActive(false);
            }
            
        }
        else if(playerNum == 4)
        {
           
            body.velocity = new Vector2(body.velocity.x, body.velocity.y);
            body.gravityScale = 1;
            obj1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            obj1.GetComponent<Rigidbody2D>().gravityScale = 0;
            obj2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            obj2.GetComponent<Rigidbody2D>().gravityScale = 0;
            obj3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            obj3.GetComponent<Rigidbody2D>().gravityScale = 0;
            PlayerPrefs.SetInt("canMove", 0);
            PlayerPrefs.SetInt("canMove2", 0);
            PlayerPrefs.SetInt("canMove3", 0);
            PlayerPrefs.SetInt("canMove4", 1);
            yield return new WaitForSeconds(5);
            if (PlayerPrefs.GetInt("canMove4") == 1)
            {
                source2.PlayOneShot(timeResumeSound);
            }
                
            yield return new WaitForSeconds(2);
            if (PlayerPrefs.GetInt("canMove4") == 1)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 10;
                obj1.GetComponent<SpriteRenderer>().sortingOrder = 10;
                obj2.GetComponent<SpriteRenderer>().sortingOrder = 10;
                obj3.GetComponent<SpriteRenderer>().sortingOrder = 10;
                body.gravityScale = 1;
                PlayerPrefs.SetInt("canMove4", 1);
                obj1.GetComponent<Rigidbody2D>().gravityScale = 1;
                PlayerPrefs.SetInt("canMove", 1);
                obj2.GetComponent<Rigidbody2D>().gravityScale = 1;
                PlayerPrefs.SetInt("canMove2", 1);
                obj3.GetComponent<Rigidbody2D>().gravityScale = 1;
                PlayerPrefs.SetInt("canMove3", 1);
                World.SetActive(false);
            }
                
        }
        
    }
    














}
