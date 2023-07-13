using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hipeboy : MonoBehaviour
{
    public float speed = 5f;
    private float leftBoundary = -10f; 

    private void Update()
    {
    
        transform.Translate(Vector3.left * speed * Time.deltaTime);

      
        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }
}
