using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool parried = false;
    [SerializeField] private float speed;
    private Transform player;
    private Rigidbody2D controller;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>().transform;
        controller = GetComponent < Rigidbody2D>();
        LaunchProjectile();
        StartCoroutine(SelfDelete());
    }
    //Calculate the distance between de projectile and the player creating a vector
    private void LaunchProjectile()
    {
        Vector2 directionToPlayer= (player.position - transform.position).normalized;
        controller.velocity=directionToPlayer*speed;
        Vector2 directionToEnemy = (transform.position - player.position).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.velocity = directionToEnemy * speed;

            Debug.Log("Se ha presionado la barra espaciadora");
            // Aquí puedes agregar lo que quieres que pase cuando se presione el espacio
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verify the colision
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); 
        }
        else if (collision.tag == "parry" && parried == false)
        {
            parried = true;
            controller.velocity *= -1;
            Debug.Log("parry");
        }
        
    }


    IEnumerator SelfDelete() {

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
