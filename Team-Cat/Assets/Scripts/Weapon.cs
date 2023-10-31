using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Monster monster = GetComponent<Monster>(); 
        //Animator animator2 = monster.animator1;
        if (collision.gameObject.CompareTag("Monster"))
        {
            
            animator.SetTrigger("dead");
            Debug.Log("collision!!");
            Invoke("LoadRetry", 2.0f);
            //animator2.speed = 0f;
            //SceneManager.LoadScene("LevelFailed");

        }
        
    }
    public void LoadRetry()
    {
        SceneManager.LoadScene("LevelFailed");
    }
}
