using UnityEngine;

public class PlayerFocus : MonoBehaviour
{

    public Transform obj1;
    public Transform obj2;
    public Transform obj3;
    public Transform obj4;

    public int selectCam = 1;
    private int moveSpeed = 100;
    private int cam1 = 1;
    private int cam2 = 2;

    private Vector2 movement;

    public float deltaY;

    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("Camera1", cam1);
        PlayerPrefs.SetInt("Camera2", cam2);
    }
    void Update()
    {

        if (selectCam == cam1)
        {
            if (PlayerPrefs.GetInt("Camera1") == 1)
            {
                Vector3 direction = obj1.position - transform.position;
                direction.Normalize();
                movement = direction;

            }
            else if (PlayerPrefs.GetInt("Camera1") == 2)
            {
                Vector3 direction = obj2.position - transform.position;
                direction.Normalize();
                movement = direction;
            }
            else if (PlayerPrefs.GetInt("Camera1") == 3)
            {
                Vector3 direction = obj3.position - transform.position;
                direction.Normalize();
                movement = direction;
            }
            else if (PlayerPrefs.GetInt("Camera1") == 4)
            {
                Vector3 direction = obj4.position - transform.position;
                direction.Normalize();
                movement = direction;
            }

        }


        if (selectCam == cam2)
        {
            if (PlayerPrefs.GetInt("Camera2") == 1)
            {
                Vector3 direction = obj1.position - transform.position;
                direction.Normalize();
                movement = direction;
            }
            else if (PlayerPrefs.GetInt("Camera2") == 2)
            {
                Vector3 direction = obj2.position - transform.position;
                direction.Normalize();
                movement = direction;
            }
            else if (PlayerPrefs.GetInt("Camera2") == 3)
            {
                Vector3 direction = obj3.position - transform.position;
                direction.Normalize();
                movement = direction;
            }
            else if (PlayerPrefs.GetInt("Camera2") == 4)
            {
                Vector3 direction = obj4.position - transform.position;
                direction.Normalize();
                movement = direction;
            }

        }
       
        

        
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
