using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class MenuSoundManager : MonoBehaviour
{

    float _volume;
    bool _mute;

    AudioSource _audioSource;
    [SerializeField] AudioClip clickSound;

    // Start is called before the first frame update
    void Start()
    {
        _volume = 1f;
        _audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickSound()
    {
        StartCoroutine(PlayKiss());
    }

    IEnumerator PlayKiss()
    {
        Debug.Log("Playing other click sound...");
        _audioSource.PlayOneShot(clickSound);
        yield return new WaitForSeconds(0.75f);
    }
}
