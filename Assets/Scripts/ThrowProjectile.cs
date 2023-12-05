using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Transform projectileSpawn;

    public float force = 100;
    
    public float coolDownTime = 10f;

    private bool canShoot = true;


    // Update is called once per frame
    void Update()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.F))
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * force);

            StartCoroutine(Cooldown());
            
            Destroy(projectile, 5f);
        }
    }

    IEnumerator Cooldown()
    {
        canShoot = false;

        yield return new WaitForSeconds(coolDownTime);

        canShoot = true;
    }
}
