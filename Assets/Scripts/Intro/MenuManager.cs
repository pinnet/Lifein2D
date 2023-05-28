using Helpers.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] private AudioClipTriggerEvent audioClipTriggerEvent;

    private void Awake()
    {
        var root = document.rootVisualElement;
        var aboutBox = root.Q<VisualElement>("AboutBox");
        var optionsBox = root.Q<VisualElement>("OptionsBox");
        var startButton = root.Q<Button>("Start");
        var optionsButton = root.Q<Button>("Options");
        var aboutButton = root.Q<Button>("About");

        startButton.RegisterCallback<MouseEnterEvent>((evt) =>
        {
            audioClipTriggerEvent.Raise(new AudioPlayerControl(AudioPlayerEvents.MouseOverButton));
        }
        ); 
        optionsButton.RegisterCallback<MouseEnterEvent>((evt) =>
        {
            audioClipTriggerEvent.Raise(new AudioPlayerControl(AudioPlayerEvents.MouseOverButton));
        }
        );
        aboutButton.RegisterCallback<MouseEnterEvent>((evt) =>
        {
            audioClipTriggerEvent.Raise(new AudioPlayerControl(AudioPlayerEvents.MouseOverButton));
        }
        );
        
        aboutButton.clicked += () => { aboutBox.ToggleInClassList("hidden"); };
        optionsButton.clicked += () => { optionsBox.ToggleInClassList("hidden"); };

        startButton.clicked += () => {
            audioClipTriggerEvent.Raise(new AudioPlayerControl(AudioPlayerEvents.GameStart));
            LoadStartScene(); 
        };

    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Main");
    }
}
