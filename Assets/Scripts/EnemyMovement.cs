using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float flMoveSpeed = 1f;
    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(flMoveSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        flMoveSpeed = -flMoveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing(){
         transform.localScale = new Vector2 (-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
}
