using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Convert mouse position to a ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the GameObject
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Deactivate the GameObject
                gameObject.SetActive(false);
            }
        }
    }
}