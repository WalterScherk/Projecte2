using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProtagonistWeapon : MonoBehaviour
{
    //private SpriteRenderer spriteRenderer;
    public new Camera camera;
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
   
    // Update is called once per frame
    void Update()
    {
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        Vector3 angle = GetAngleTowardsMouse();

        //transform.rotation = Quaternion.Euler(0, 0, angle);
        //spriteRenderer.flipY = angle >= 90 && angle <= 270;
    }

    private Vector3 GetAngleTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToViewportPoint(Input.mousePosition);

        Vector3 mouseDirection = Vector3.Normalize(mouseWorldPosition - transform.position);
        mouseDirection.z = 0;

        //float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;
        return mouseDirection; 
    }
}

