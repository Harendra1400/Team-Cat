using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Weapon : MonoBehaviour
{
    [SerializeField] private AudioSource GunShotEffect;
    [SerializeField] private AudioSource GameoverEffect;
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int maxInstances = 1;
    private int currentInstances = 0;
    public bool canTriggerAnimation = true;
    [SerializeField] private AudioSource MonsterHitEffect;
    public Animator animator1;
    public float speed = 13f;
    public Rigidbody2D rb;
    private Vector3 originalPosition;
    public Button[] buttons;
    public MathGameController triggervar;

    private void Start()
    {
        originalPosition = transform.position;
        rb.velocity = transform.right * speed;
        addListen();
       
    }
    void Update()
    {
      
    }
    private void addListen()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i;

            buttons[i].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }
    private void OnButtonClick(int buttonIndex)
    {
        int buttonValue;
        bool isParsed = int.TryParse(buttons[buttonIndex].GetComponentInChildren<Text>().text, out buttonValue);
        if (isParsed && buttonValue == triggervar.correctAnswer)
        {
            Debug.Log(buttonValue);
            buttons[buttonIndex].name = "answer";
            Debug.Log("Correct button selected!");
            if (canTriggerAnimation)
            {
                CorrectButtonClicked();
            }
        }
    }
    private void CorrectButtonClicked()
    {
        Shoot();
        canTriggerAnimation = false;
        StartCoroutine(ResetTriggerFlag(1f));
        addListen();
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
            Invoke("LoadRetry", 1.0f);
          

        }
        
    }
    
    public void LoadRetry()
    {
        SceneManager.LoadScene("try");
    }
}
