using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class MenuManager : MonoBehaviour
{

    float _volume;
    bool _mute;

    AudioSource _audioSource;
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip menuMusic;

    // Start is called before the first frame update
    void Start()
    {
        _volume = 1f;
        _mute = false;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = menuMusic;
        SetupListeners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupListeners()
    {
        EventBus.Subscribe(EventBus.EventType.StartGame, LoadStartGame);
    }

    void LoadStartGame()
    {
        _audioSource.PlayOneShot(clickSound);
        Debug.Log("Loading Game...");
        DontDestroyOnLoad(gameObject);
        _audioSource.clip = null;
        SceneManager.LoadScene("WorldMap");
        CleanupListeners();
    }

    void CleanupListeners()
    {
        EventBus.Unsubscribe(EventBus.EventType.StartGame, LoadStartGame);
    }

}
