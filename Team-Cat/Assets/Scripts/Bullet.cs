using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioSource MonsterHitEffect;
    public Animator animator;
    public float speed = 13f;
    public Rigidbody2D rb;
    private Vector3 originalPosition;
 
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
        rb.velocity = transform.right * speed;
       
    }
}
