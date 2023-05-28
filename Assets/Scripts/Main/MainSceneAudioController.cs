using Helpers.CustomEditor;
using Helpers.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainSceneAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [NamedArrayAttribute(new string[] { "MouseOverButton","MouseClickButton","GameStart","GameEnd"})]
    public AudioClip[] audioClips;

    public void PlayClip(AudioPlayerControl audioControl)
    {
        switch (audioControl.Trigger)
        {
            case AudioPlayerEvents.MouseOverButton:
                audioSource.PlayOneShot(audioClips[0]);
                break;
            case AudioPlayerEvents.MouseClickButton:
                audioSource.PlayOneShot(audioClips[1]);
                break;
            case AudioPlayerEvents.GameStart:
                audioSource.PlayOneShot(audioClips[2]);
                break;
            case AudioPlayerEvents.GameEnd:
                audioSource.PlayOneShot(audioClips[3]);
                break;
            default:
                break;
        }
    }
}
