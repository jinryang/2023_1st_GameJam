using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 campos = target.position;

        campos.z = -10;
        campos.x = (int)((target.position.x + 6) * 0.05f) * 20;
        transform.position = target.position;
        if (campos.y < -6) campos.y = -6;
        if (campos.y > 6) campos.y = 6;

        transform.position = campos;
    }
}
