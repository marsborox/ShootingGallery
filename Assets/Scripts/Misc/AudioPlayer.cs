using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour/*Singleton<AudioPlayer>*/
{
    public float defaultVolume;
    /*protected override*/ void Awake()
    {
        //base.Awake();
    }
    public void PlayClip(AudioClip clip/*, float volume*/)
    {
        //Debug.Log("audioPlayer. Playing AudioClip");
        if (clip != null)
        {//camera, main camera, at position where it is
            Vector3 cameraPos = Camera.main.transform.position;
            //play clip (which clip, where, how loud)
            AudioSource.PlayClipAtPoint(clip, cameraPos, defaultVolume);
        }
    }
}
