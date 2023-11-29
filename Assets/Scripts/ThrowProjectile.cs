using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Transform projectileSpawn;

    public float force = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * force);
            
            Destroy(projectile, 5f);
        }
    }
}
