using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowPurple : MonoBehaviour
{
    public float rotated = 0;
    public float speed = 1;
    private Rigidbody2D body;

    // Update is called once per frame

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
       

    }
    private void Update()
    {
        if (body.velocity.x != 0)
        {
            StartCoroutine(Destroyed());
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotated);
            rotated += speed * 100 * Time.deltaTime;

        }
        
    }

    IEnumerator Destroyed()
    {

        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
