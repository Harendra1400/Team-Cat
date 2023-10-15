using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
        }
    }

    public void Shoot()
    {
        animator.SetTrigger("shoot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
