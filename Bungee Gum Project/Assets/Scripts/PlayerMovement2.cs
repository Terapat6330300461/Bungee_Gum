using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float startX;
    [SerializeField] private float startY;

    public GameObject canvas0;
    public GameObject canvas;
    public GameObject scoretext;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;


    public GameObject World;

    public int ranking = 0;

    private int playerNum = 2;

    private Rigidbody2D body;

    private bool Grounded;

    private float dukdik = 0;
    private bool step = true;
    private float rotateY = 0f;



    public AudioSource source;
    public AudioClip deathSound;

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


    public GameObject diamond;

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

        PlayerPrefs.SetInt("itemSprite2", 0);
        scoretext.GetComponent<Text>().text = PlayerPrefs.GetInt("scoretext2").ToString("F0");

        charging = false;
        delayZawarudo = false;


    }




    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {


        if (GetComponent<SpriteRenderer>().sortingOrder == 101)
        {
            diamond.GetComponent<SpriteRenderer>().sortingOrder = 101;
        }
        else
        {
            diamond.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }



        //flip player when move left or rigt
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && PlayerPrefs.GetInt("canMove2") == 1 && charging == false)
        {
            rotateY = 0f;
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


            body.velocity = new Vector2(speed * seedMode * 100 * Time.fixedDeltaTime, body.velocity.y);

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && PlayerPrefs.GetInt("canMove2") == 1 && charging == false)
        {
            rotateY = 180f;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z + dukdik);
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

            body.velocity = new Vector2(-speed * seedMode * 100 * Time.fixedDeltaTime, body.velocity.y);

        }

        else
        {
            step = true;
            dukdik = 0;
            transform.rotation = Quaternion.Euler(transform.rotation.x, rotateY, dukdik);
            body.velocity = new Vector2(0, body.velocity.y);
        }

        //player will jump when press spacebar

        if (Input.GetKey(KeyCode.UpArrow) && Grounded && PlayerPrefs.GetInt("canMove2") == 1 && charging == false)
        {
            
            body.velocity = new Vector2(body.velocity.x, speed * 100 * 2 * Time.fixedDeltaTime);
            Grounded = false;
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (gotItem)
            {

                if (itemDevilFruit)
                {
                    source2.PlayOneShot(roomSound);
                    var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
                    itemDevilFruit = false;
                    PlayerPrefs.SetInt("itemSprite2", 0);
                    gotItem = false;
                }

                if (itemSixEyes)
                {
                    body.velocity = new Vector2(body.velocity.x, 0);
                    body.gravityScale = 0;
                    charging = true;
                    source2.PlayOneShot(hollowPurpleSound);
                    StartCoroutine(HollowPurple());
                    itemSixEyes = false;
                    PlayerPrefs.SetInt("itemSprite2", 0);
                    gotItem = false;
                }
                if (itemSeed)
                {
                    source2.PlayOneShot(seedModeSound);
                    seedMode = 2;
                    StartCoroutine(SeedMode());
                    itemSeed = false;
                    PlayerPrefs.SetInt("itemSprite2", 0);
                    gotItem = false;

                }
                if (GetComponent<SpriteRenderer>().sortingOrder != 101)
                {
                    if (itemStand && delayZawarudo == false)
                    {

                        StartCoroutine(Zawarudo());
                        itemStand = false;
                        PlayerPrefs.SetInt("itemSprite2", 0);
                        gotItem = false;

                    }
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
                    PlayerPrefs.SetInt("itemSprite2", 0);
                    gotItem = false;
                }

            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Ball")
        {

            Grounded = true;

        }

        if (collision.gameObject.tag == "Platform")
        {
            source.PlayOneShot(deathSound);
            transform.position = new Vector2(startX, startY);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            source.PlayOneShot(deathSound);
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
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Head"))
        {
            if (collision.gameObject.name != "Player 2 Head")
            {
                Grounded = true;
            }


        }

        if (collision.CompareTag("Item"))
        {

            if (gotItem == false)
            {
                if (collision.gameObject.name == "Devil Fruit" || collision.gameObject.name == "Devil Fruit(Clone)")
                {
                    PlayerPrefs.SetInt("itemSprite2", 1);
                    itemDevilFruit = true;
                }
                else if (collision.gameObject.name == "Six Eyes" || collision.gameObject.name == "Six Eyes(Clone)")
                {
                    PlayerPrefs.SetInt("itemSprite2", 2);
                    itemSixEyes = true;
                }
                else if (collision.gameObject.name == "Seed" || collision.gameObject.name == "Seed(Clone)")
                {
                    PlayerPrefs.SetInt("itemSprite2", 3);
                    itemSeed = true;
                }
                else if (collision.gameObject.name == "Stand" || collision.gameObject.name == "Stand(Clone)")
                {
                    PlayerPrefs.SetInt("itemSprite2", 4);
                    itemStand = true;
                }
                else if (collision.gameObject.name == "Ghost" || collision.gameObject.name == "Ghost(Clone)")
                {

                    PlayerPrefs.SetInt("itemSprite2", 5);
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

    private void OnTriggerExit2D(Collider2D collision)
    {
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
        GetComponent<SpriteRenderer>().sortingOrder = 101;
        obj1.GetComponent<SpriteRenderer>().sortingOrder = 10;
        obj2.GetComponent<SpriteRenderer>().sortingOrder = 10;
        obj3.GetComponent<SpriteRenderer>().sortingOrder = 10;
        World.SetActive(true);
        body.velocity = new Vector2(body.velocity.x, body.velocity.y);
        body.gravityScale = 1;
        obj1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        obj1.GetComponent<Rigidbody2D>().gravityScale = 0;
        obj2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        obj2.GetComponent<Rigidbody2D>().gravityScale = 0;
        obj3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        obj3.GetComponent<Rigidbody2D>().gravityScale = 0;
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
            obj2.GetComponent<SpriteRenderer>().sortingOrder = 10;
            obj3.GetComponent<SpriteRenderer>().sortingOrder = 10;
            body.gravityScale = 1;
            PlayerPrefs.SetInt("canMove2", 1);
            obj1.GetComponent<Rigidbody2D>().gravityScale = 1;
            PlayerPrefs.SetInt("canMove", 1);
            obj2.GetComponent<Rigidbody2D>().gravityScale = 1;
            PlayerPrefs.SetInt("canMove3", 1);
            obj3.GetComponent<Rigidbody2D>().gravityScale = 1;
            PlayerPrefs.SetInt("canMove4", 1);
            World.SetActive(false);
        }

    }
    



}
