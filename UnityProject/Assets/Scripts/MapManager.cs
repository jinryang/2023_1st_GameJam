using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    GameObject player;
    public GameObject[] portals;
    private bool portalopen=false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ClosePortal()
    {
        portalopen = false;
        for (int i = 0; i < portals.Length; i++)
        {
            portals[i].SetActive(false);
        }
    }

    public void Update()
    {
        if (!portalopen && player.GetComponent<PlayerAttack>().GetCount() < 1)
        {
            Debug.Log("a");
            portalopen = true;
            for(int i=0; i<portals.Length;i++)
            {
                portals[i].SetActive(true);
            }
        }
    }
}
