using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeGhostAttack : MonoBehaviour
{
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

        }

    }

    IEnumerator Destroyed()
    {

        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}