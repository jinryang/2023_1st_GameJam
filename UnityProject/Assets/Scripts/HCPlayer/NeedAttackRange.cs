using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedAttackRange : MonoBehaviour
{
    bool IsDamaged = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!IsDamaged)
                collision.gameObject.GetComponent<PlayerInfo>().GetDamage(1);
            IsDamaged = true;
        }
    }
}
