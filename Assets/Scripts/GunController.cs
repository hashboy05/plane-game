using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private float gunDistance = 0f;
    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    private float shootTimer = 0f; // Timer to track shooting interval
    private float shootInterval = 0.75f; // Time interval for shooting downwards
    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        // Rotate the gun to face the mouse position
        gun.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        // Calculate the angle to position the gun
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(gunDistance, 0, 0);


        if (transform.name=="playerplane"){
            // Shoot bullets towards the north direction (upwards)
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot(Vector3.up); // Change direction to Vector3.up for shooting upwards
            }
        }
        else{
            // Update the shoot timer
            shootTimer += Time.deltaTime;
            // Check if enough time has passed to shoot downwards
            if (shootTimer >= shootInterval)
            {
                Shoot(Vector3.down); // Change direction to Vector3.down for shooting downwards
                shootTimer = 0f; // Reset the timer after shooting
            }
        }
    }

    public void Shoot(Vector3 direction){
        GameObject newBullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        Destroy(newBullet,1);
    }
}
