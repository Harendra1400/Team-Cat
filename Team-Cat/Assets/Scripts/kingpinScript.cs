using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kingpinScript : MonoBehaviour
{
    [SerializeField] private AudioSource MonsterHitEffect;
    public Animator animator;
    private float _speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * _speed));
    }

    private void OnTriggerEnter2D (Collider2D hitInfo)
    {
        //Destroy(gameObject);
        if(hitInfo.CompareTag("Bullet"))
        {
            Destroy(hitInfo.gameObject);//destroy bullet
            MonsterHitEffect.Play();
            animator.SetTrigger("BossExplode");
            Invoke("Delaydestroy", 1.0f);
            
        }
    }
    private void Delaydestroy()
    {
        Destroy(gameObject);
    }
}
