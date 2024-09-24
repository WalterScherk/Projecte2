using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float movSpeed;
    public Rigidbody2D Controler;

    public BoxCollider2D swingArea;
    public Camera cam;

    public PlayerBullet myBullet;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space)) {
            ParryAction();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootAction();
        }
    }

    void FixedUpdate()
    {
        Controler.MovePosition(Controler.position + movement * movSpeed * Time.fixedDeltaTime);
    }

    private void ParryAction()
    {

        if (swingArea.enabled == false) {
            //spawn area for sword swing
            swingArea.enabled = true;

            //stop the swing
            StartCoroutine(StopSwing());
        }
    }

    private void ShootAction() {
        //get direction of mouse
        //Vector3 mouseWorldPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 mouseWorldPosition = Input.mousePosition-Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mouseDirection = Vector3.Normalize(mouseWorldPosition - gameObject.transform.position);

        PlayerBullet oneMoreBullet = Instantiate(myBullet, transform.position, Quaternion.identity);
        oneMoreBullet.direction = mouseDirection;
        Debug.Log(mouseDirection);

        /*Debug.DrawLine(gameObject.transform.position,
            mouseDirection+gameObject.transform.position,
            Color.white, 2.0f);*/
    }

    IEnumerator StopSwing()
    {
        yield return new WaitForSeconds(0.2f);
        swingArea.enabled = false;
        
    }


    
}

