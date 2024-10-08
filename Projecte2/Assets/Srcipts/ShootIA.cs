using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIA : MonoBehaviour
{
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private float timeBetweenShoots;   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());//with this i call the iteration
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerBullet") {

            Destroy(gameObject);
        }
    }

    IEnumerator Shoot()//With this the proyectile repeat the shoot 
    {
        yield return new WaitForSeconds(timeBetweenShoots);
        Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        StartCoroutine(Shoot());
    }
}
