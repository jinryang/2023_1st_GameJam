using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KisinCircleWave : MonoBehaviour
{
    public float spread;
    public float LifeTime;
    PlayerInfo playerInfo;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //АјАн
            playerInfo = collision.GetComponent<PlayerInfo>();
            playerInfo.GetDamage(0);
        }
    }

    void Update()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + spread * Time.deltaTime, gameObject.transform.localScale.y + spread * Time.deltaTime, gameObject.transform.localScale.z);
        LifeTime -= Time.deltaTime;
        if (LifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
