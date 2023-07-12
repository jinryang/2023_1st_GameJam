using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
    public int damage;
    public GameObject target;

    private void Start()
    {
        dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        dir.Normalize();
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
        if(Vector3.Distance(transform.position, target.transform.position) > 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerInfo>().GetDamage(damage);
        }
        if (collision.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
