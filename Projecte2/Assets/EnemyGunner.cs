using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : MonoBehaviour
{
    public GameObject player;
    private Vector3 direction;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get direction from enemy to player
        direction = Vector3.Normalize(player.transform.position-gameObject.transform.position);


        Debug.DrawLine(gameObject.transform.position, new Vector2(direction.x + gameObject.transform.position.x,
            direction.y + gameObject.transform.position.y),
            Color.white, 2.0f);
    }
}
