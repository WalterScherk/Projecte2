using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private float speed = 30;

    public Vector2 direction;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(SelfDelete());
    }


   

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "bullet") {
            Destroy(gameObject);
        }
        
        
    }

    IEnumerator SelfDelete()
    {

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }


}