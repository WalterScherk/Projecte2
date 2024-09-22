using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : MonoBehaviour
{
    public GameObject player;
    Vector2 distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get vector from enemy to player
        distance = gameObject.transform.position - player.GetComponent<Transform>().position;

        //get the module of the vector
        float module = Mathf.Sqrt(distance.x*distance.x + distance.y*distance.y);

        //create an angle from which to shoot with module and distance
        Vector2 angle = distance;
        angle.x = (angle.x / module) * 10;
        angle.y = (angle.y / module) * 10;

        Debug.DrawLine(gameObject.transform.position, angle, Color.white, 10.0f);
    }
}
