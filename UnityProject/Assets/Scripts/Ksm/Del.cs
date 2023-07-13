using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del : MonoBehaviour
{
    float time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;
        if (time > 2f)
        {
            Destroy(gameObject);
        }
    }
}
