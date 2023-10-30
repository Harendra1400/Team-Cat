using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed = 13f;
    public Rigidbody2D rb;
    //public GameObject monsterPrefab;
    //public GameObject newMonster;
    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        rb.velocity = transform.right * speed;
        Debug.Log(originalPosition.x);
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
