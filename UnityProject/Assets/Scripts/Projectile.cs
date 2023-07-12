using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 TargetPoint;
    private Vector3 dir;

    public void SetTarget(GameObject Target)
    {
        TargetPoint = Target.transform.position;
        SetDirection();
    }

    void Update()
    {
        transform.Translate(dir*10*Time.deltaTime);
    }

    private void SetDirection()
    {
        dir = new Vector3(TargetPoint.x, TargetPoint.y, 0) - this.transform.position;
        dir.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            ObjectPooling.instance.InsertPool(gameObject);
        }
        if(collision.tag == "wall")
        {
            ObjectPooling.instance.InsertPool(gameObject);
        }
    }
}
