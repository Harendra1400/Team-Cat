using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Weapon : MonoBehaviour
{
    [SerializeField] private AudioSource GunShotEffect;
    [SerializeField] private AudioSource GameoverEffect;
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int maxInstances = 1;
    private int currentInstances = 0;
    private bool canTriggerAnimation = true;
    

    // Update is called once per frame
    void Update()
    {
       if((Input.GetButtonDown("Fire1")) && canTriggerAnimation)
        {
            
            Shoot();
            canTriggerAnimation = false;
            StartCoroutine(ResetTriggerFlag(1f));
        }
    }

    public void Shoot()
    {
        GunShotEffect.Play();
        animator.SetTrigger("shoot");
        if (currentInstances < maxInstances)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                currentInstances++;
                StartCoroutine(ResetCurrentInstances(1f));
            }
    }
    IEnumerator ResetCurrentInstances(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentInstances = 0;
    }

    IEnumerator ResetTriggerFlag(float delay)
    {
        yield return new WaitForSeconds(delay);
        canTriggerAnimation = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("Monster"))
        {
            
            animator.SetTrigger("dead");
            GameoverEffect.Play();
            Debug.Log("collision!!");
            Invoke("LoadRetry", 2.0f);
          

        }
        
    }
    
    public void LoadRetry()
    {
        SceneManager.LoadScene("try");
    }
}
