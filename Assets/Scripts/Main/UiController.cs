using Helpers.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UiController : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private VoidEvent startGame;
    [SerializeField] private AudioClipTriggerEvent audioClipTriggerEvent;
    Button startButton,restartButton,settingsButton;
    private void Awake()
    {
        var root = document.rootVisualElement;
        startButton = root.Q<Button>("GoButton");
        restartButton = root.Q<Button>("RestartButton");
        settingsButton = root.Q<Button>("SettingsButton");

        startButton.ToggleInClassList("hidden");

        startButton.RegisterCallback<MouseEnterEvent>((evt) =>
        {
            audioClipTriggerEvent.Raise(new AudioPlayerControl(AudioPlayerEvents.MouseOverButton));
        }
        );

        startButton.clicked += () => 
        { 
            startGame.Raise();
            audioClipTriggerEvent.Raise(new AudioPlayerControl(AudioPlayerEvents.GameStart));
            startButton.ToggleInClassList("hidden");
            restartButton.ToggleInClassList("hidden");
        };
    }
    
    public void UpdateUI(UIData data)
    {
        if(typeof(UIData) != data.GetType()) return;    
        StatusUpdate(data.status);
        UpdateMove(data.startMoves);
        UpdateScore(data.score);
        UpdateGeneration(data.generation);
    }
    public void UpdateGeneration(string? value)
    {
        if (value == null) return;
        var root = document.rootVisualElement;
        var generationLabel = root.Q<Label>("GenerationText");
        generationLabel.text = value;
    }
    public void UpdateScore(string? value)
    {
        if (value == null) return;
        var root = document.rootVisualElement;
        var scoreLabel = root.Q<Label>("ScoreText");
        scoreLabel.text = value;
    }
    public void UpdateMove(string? value)
    {
        if (value == null) return;
        var root = document.rootVisualElement;
        var moveLabel = root.Q<Label>("MoveText");
        moveLabel.text = value;
    }
    public void StatusUpdate(string? value)
    {
        if (value == null) return;
        var root = document.rootVisualElement;
        var statusLabel = root.Q<Label>("StatusText");
        statusLabel.text = value;    
    }
}
