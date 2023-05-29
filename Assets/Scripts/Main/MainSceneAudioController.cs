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
                if (audioClips[0] == null) break;
                if (!audioSource.isPlaying) audioSource.PlayOneShot(audioClips[0]);
                break;
            case AudioPlayerEvents.MouseClickButton:
                if (audioClips[1] == null) break;
                audioSource.PlayOneShot(audioClips[1]);
                break;
            case AudioPlayerEvents.GameStart:
                if (audioClips[2] == null) break;
                audioSource.PlayOneShot(audioClips[2]);
                break;
            case AudioPlayerEvents.GameEnd:
                if (audioClips[3] == null) break;
                audioSource.PlayOneShot(audioClips[3]);
                break;
            default:
                break;
        }
    }
}
