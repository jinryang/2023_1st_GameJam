using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeNeedMore : MonoBehaviour
{
    bool IsBossStart = false;
    float Stimer = 0;
    public GameObject NeedMore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBossStart)
        {
            Stimer += Time.deltaTime;
            if (Stimer >= 21.0f)
            {
                Instantiate(NeedMore);
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            IsBossStart = true;
        }
    }
}
