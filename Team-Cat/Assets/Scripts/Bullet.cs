using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed = 13f;
    public Rigidbody2D rb;
   // public GameObject monsterPrefab;
    //public GameObject newMonster;
    private Vector3 originalPosition;
 
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        rb.velocity = transform.right * speed;
        //GameObject newMonster= Instantiate(monsterPrefab);
        //Debug.Log("x position is {0}",originalPosition.x);
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Destroy(gameObject);
        if(hitInfo.gameObject.tag.Equals("Monster"))
        {
            
            //monsterPrefab = hitInfo.gameObject.GetComponent<GameObject>();
            Destroy(hitInfo.gameObject);
            //newMonster.SetActive(true);


        }
    }
}
