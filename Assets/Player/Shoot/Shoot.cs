using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform bulletPrefab;
    public Transform camera;
    private bool isShoot = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isShoot = true;
        }
    }

    private void FixedUpdate()
    {
        if (isShoot)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            bullet.AddForce(camera.forward * 30, ForceMode.Impulse);
            isShoot = false;
        }
    }

    private void ShootBullet()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            bullet.AddForce(camera.forward * 30, ForceMode.Impulse);
        }
    }
}
