using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class MenuManager : MonoBehaviour
{

    float _volume;
    bool _mute;

    AudioSource _audioSource;
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip menuMusic;

    public Animator animator;
    bool open;

    // Start is called before the first frame update
    void Start()
    {
        _volume = 1f;
        _mute = false;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = menuMusic;
        open = false;
        SetupListeners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupListeners()
    {
        EventBus.Subscribe(EventBus.EventType.StartGame, LoadStartGame);
        EventBus.Subscribe(EventBus.EventType.Credits, LoadCredits);
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

    void LoadCredits()
    {
        _audioSource.PlayOneShot(clickSound);
        Debug.Log("Toggling Credits...");
        open = !open;
        animator.SetBool("IsOpen", open);
    }

    void CleanupListeners()
    {
        EventBus.Unsubscribe(EventBus.EventType.StartGame, LoadStartGame);
        EventBus.Unsubscribe(EventBus.EventType.Credits, LoadCredits);
    }

}
