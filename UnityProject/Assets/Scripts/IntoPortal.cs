using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class IntoPortal : MonoBehaviour
{
    public GameObject monsterWave;
    GameObject player;
    GameObject playerMover;
    MapManager mapmanager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMover = GameObject.FindGameObjectWithTag("PlayerMover");
        mapmanager = GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mapmanager.ClosePortal();
            if (null == monsterWave)
            {
                SceneManager.LoadScene("EndingScene");
            }
            Vector3 pos = transform.position;
            pos.x += 20;
            pos.y -= 16f;
            playerMover.transform.position = pos;
            player.transform.position = pos;
            Debug.Log(pos + ", " + player.transform.position);
            
            Instantiate(monsterWave);
            player.GetComponent<PlayerAttack>().NewWave();
        }
    }
}
