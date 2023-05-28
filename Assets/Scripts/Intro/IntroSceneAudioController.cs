using Helpers.CustomEditor;
using Helpers.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IntroSceneAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [NamedArrayAttribute(new string[] { "MouseOverButton", "MouseClickButton", "GameStart" })]
    public AudioClip[] audioClips;

    public void PlayClip(AudioPlayerControl audioClipPlay)
    {
        switch (audioClipPlay.Trigger)
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
            default:
                break;
        }
    }
}
