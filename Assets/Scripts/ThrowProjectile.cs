using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ThrowProjectile : MonoBehaviour
{
    public GameObject[] projectilePrefab;

    public Transform projectileSpawn;

    public Slider cooldownSlider;

    public float force = 100;
    
    public float cooldownTime = 10f;
    public float cooldownCurrent;
    
    private bool canShoot = true;
    
    private void Start()
    {
        cooldownCurrent = cooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownCurrent += Time.deltaTime;
        cooldownCurrent = Mathf.Clamp(cooldownCurrent, 0.0f, cooldownTime);

        cooldownSlider.value = cooldownCurrent / cooldownTime;
    }

    public void OnThrow(InputAction.CallbackContext value)
    {
        if (canShoot)
        {
            GameObject projectile = Instantiate(projectilePrefab[Random.Range(0, projectilePrefab.Length)], projectileSpawn.position, projectileSpawn.transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * force);

            StartCoroutine(Cooldown());
            
            Destroy(projectile, 5f);
        }
    }

    IEnumerator Cooldown()
    {
        canShoot = false;

        cooldownCurrent = 0f;

        yield return new WaitForSeconds(cooldownTime);

        canShoot = true;
    }
}
