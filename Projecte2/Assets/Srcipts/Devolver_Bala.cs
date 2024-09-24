using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devolver_Bala : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    private Transform enemy;
    private Rigidbody2D controller;
    [SerializeField] private GameObject ProjectilePrefab;
    void Start()
    {
        controller = GetComponent<Rigidbody2D>();
        enemy = FindObjectOfType<ShootIA>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToEnemy = (enemy.position - transform.position).normalized;
        
        if (Input.GetKeyDown(KeyCode.Space)&& directionToEnemy.magnitude<5)
        {
            controller.velocity = directionToEnemy * speed;

            Debug.Log("Se ha presionado la barra espaciadora");
            // Aquí puedes agregar lo que quieres que pase cuando se presione el espacio
        }
    }
}
