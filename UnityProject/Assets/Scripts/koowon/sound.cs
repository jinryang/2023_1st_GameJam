using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip clip;

    private void Awake()
    {
        soundManager.instance.SFXplay("hypeboy", clip, 2f, 5.5f);

        GameObject hiboy1Object = new GameObject("hiboy1");
        hiboy1Object.AddComponent<AudioSource>().clip = clip;
        hiboy1Object.AddComponent<hipeboy>();
    }
}
