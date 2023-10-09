using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CloudGeneratorScript : MonoBehaviour
    {
        [SerializeField]
        GameObject[] clouds;

        [SerializeField]
        float spawnInterval;

        [SerializeField]
        GameObject endPoint;

        Vector3 startPos;

        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.position;
            Invoke("AttemptSpawn", spawnInterval);
        }

        void SpawnCloud()
        {
            int randomIndex = Random.Range(0, clouds.Length);
            GameObject cloud = Instantiate(clouds[randomIndex]);

            startPos.y = Random.Range(startPos.y - 0.5f, startPos.y + 0.5f);
            cloud.transform.position = startPos;

            float scale = Random.Range(0.4f, 0.7f);
            cloud.transform.localScale = new Vector2(scale, scale);

            float rangee = Random.Range(1.0f, 2.5f);
            cloud.GetComponent<CloudScript>().StartFloating(rangee, endPoint.transform.position.x);
        }

        void AttemptSpawn()
        {
            SpawnCloud();
            Invoke("AttemptSpawn", spawnInterval);
        }
    }
}