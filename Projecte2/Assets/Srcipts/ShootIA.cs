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
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeBetweenShoots);
            Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        }
        
    }
}
