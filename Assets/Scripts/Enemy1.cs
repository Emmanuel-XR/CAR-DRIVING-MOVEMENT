using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject player;
    public Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookdirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookdirection * speed);

        if (transform.position.y < 10)
        {
            Destroy(gameObject);
        }


    }
}
