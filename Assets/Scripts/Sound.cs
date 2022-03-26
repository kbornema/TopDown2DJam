using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private AudioSource _source = default;

    private void Update()
    {
        if (!_source.isPlaying)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public static void Play(AudioClip clip)
    {
        var sound = Resources.Load<Sound>("Sound");

        if (sound != null)
        {
            var instance = GameObject.Instantiate(sound);
            instance._source.clip = clip;
            instance._source.loop = false;
            instance._source.Play();
        }
    }

    public static void Play(List<AudioClip> clips)
    {
        if (clips != null && clips.Count > 0)
        {
            var clip = clips[UnityEngine.Random.Range(0, clips.Count)];
            Play(clip);
        }
    }
}
