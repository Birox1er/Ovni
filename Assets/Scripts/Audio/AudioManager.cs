using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private float _volume;
    [SerializeField] private float _pitch;
    [SerializeField] private bool _loop;
    [SerializeField] private bool _playOnAwake;

    public static AudioManager Instance { get => _instance; }
    public AudioSource AudioSource { get => _audioSource; set => _audioSource = value; }
    public AudioClip Clip { get => _clip; set => _clip = value; }
    public float Volume { get => _volume; set => _volume = value; }
    public float Pitch { get => _pitch; set => _pitch = value; }
    public bool Loop { get => _loop; set => _loop = value; }
    public bool PlayOnAwake { get => _playOnAwake; set => _playOnAwake = value; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = Clip;
        AudioSource.volume = Volume;
        AudioSource.pitch = Pitch;
        AudioSource.loop = Loop;
        AudioSource.playOnAwake = PlayOnAwake;
        Play();
    }

    public void Play()
    {
        AudioSource.Play();
    }

    public void Stop()
    {
        AudioSource.Stop();
    }

    public void Pause()
    {
        AudioSource.Pause();
    }

    public void UnPause()
    {
        AudioSource.UnPause();
    }
}
