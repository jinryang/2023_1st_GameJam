using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

          
            audioSource = gameObject.AddComponent<AudioSource>();   
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXplay(string sfxname, AudioClip clip, float startTime, float endTime)
    {
        GameObject go = new GameObject(sfxname + "Sound");

        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.time = startTime; 
        audioSource.Play();

        float duration = endTime - startTime;
        StartCoroutine(DestroyAfterClipLength(go, duration));
    }

    private IEnumerator DestroyAfterClipLength(GameObject go, float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(go);

        GameObject hiboy1 = GameObject.Find("hiboy1");
        if (hiboy1 != null)
        {
            Destroy(hiboy1);
        }
    }
}
