using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    GameObject imageGrid;
    GameObject toastPanal;

    public GameObject _NeedMore;
    public GameObject _RealNeedMore;
    public GameObject Player;

    private void Start()
    {
        imageGrid = GameObject.Find("NeedMoreChangeImage");
        toastPanal = GameObject.Find("NeedCanvers");
        toastPanal.SetActive(false);
       
    }
    public void Update()
    {
        if(Player == null)
        {
            Player = GameObject.Find("Player");
        }
    }

    public void StartBlink(GameObject NeedMore)
    {
        Debug.Log(imageGrid);
        toastPanal.SetActive(true);
        _NeedMore = NeedMore;
        StartCoroutine(EMarkerGrid(NeedMore));
    }

    public void EndChange()
    {
        Destroy(_NeedMore);
        Player.GetComponent<PlayerAttack>().AddGos(Instantiate(_RealNeedMore));
    }

    IEnumerator EMarkerGrid(GameObject NeedMore)
    {
        yield return new WaitForSeconds(0.1f);
        this.imageGrid.SetActive(false);

    }
}

