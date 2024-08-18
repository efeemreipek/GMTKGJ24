using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public GameObject ButtonClickAudioPrefab;
    public GameObject PositiveEventAudioPrefab;
    public GameObject NegativeEventAudioPrefab;

    private void Awake()
    {
        Instance = this;
    }
    public void CreateAudioGO(GameObject audioGO, float volume = 1f)
    {
        Instantiate(audioGO);
        audioGO.GetComponent<AudioSource>().volume = volume;
    }
}
