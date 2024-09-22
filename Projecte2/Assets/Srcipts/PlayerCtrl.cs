using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float movSpeed;
    public Rigidbody2D Controler;
    // Start is called before the first frame update
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //input
    }

    void FixedUpdate()
    {
        Controler.MovePosition(Controler.position + movement * movSpeed * Time.fixedDeltaTime);
    }
}

