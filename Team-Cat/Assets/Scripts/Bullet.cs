using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed = 13f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Destroy(gameObject);
        if(hitInfo.gameObject.tag.Equals("Monster"))
        {
            Destroy(hitInfo.gameObject);
            //SceneManager.LoadScene("Retry");

        }
    }
}
