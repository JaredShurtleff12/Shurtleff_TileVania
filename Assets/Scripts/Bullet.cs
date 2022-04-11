using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float flBulletSpeed = 20f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float flXSpeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        flXSpeed = player.transform.localScale.x * flBulletSpeed;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2 (flXSpeed,0f);
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }   
        Destroy(gameObject); 
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}
