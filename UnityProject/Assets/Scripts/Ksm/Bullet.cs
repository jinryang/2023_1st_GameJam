using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusin
{
    public class Bullet : MonoBehaviour
    {
        public float Speed;
        public float WaitTime;
        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnTriggerEnter2D(Collider collision)
        {
            if(WaitTime < 0)
            {
                if (collision.CompareTag("Wall"))
                {
                    Destroy(gameObject);
                }
                else if (collision.CompareTag("Player"))
                {
                    //����
                    Destroy(gameObject);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(WaitTime > 0)
            {
                WaitTime -= Time.deltaTime;
            }
            else
            {
                gameObject.transform.Translate(new Vector3(Speed, 0, 0) * Time.deltaTime, Space.Self);
            }
        }
    }
}