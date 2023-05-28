using Helpers.CustomEditor;
using Helpers.Events;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("!! Trying to create another singleton? destroying this one !! :" + this);
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    [SerializeField] private AudioSource audioSource;
    public AudioClip[] audioClips;

    public void onAudioControlGameEvent(AudioPlayerControl audioControl)
    {
        switch (audioControl.Trigger)
        {
            case AudioPlayerEvents.MusicStart:
                
                break;
            case AudioPlayerEvents.MusicStop:
                
                break;
            default:
                break;
        }
    }
}
