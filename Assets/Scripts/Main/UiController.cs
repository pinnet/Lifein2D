#nullable enable

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

    private void Awake()
    {
        var root = document.rootVisualElement;
        var startButton = root.Q<Button>("GoButton");
        
        startButton.RegisterCallback<MouseEnterEvent>((evt) =>
        {
            audioClipTriggerEvent.Raise(new AudioPlayerControl(AudioPlayerEvents.MouseOverButton));
        }
        );

        startButton.clicked += () => 
        { 
            startGame.Raise();
            audioClipTriggerEvent.Raise(new AudioPlayerControl(AudioPlayerEvents.GameStart));
        };
    }

    public void UpdateUI(UIData data)
    {
        if(typeof(UIData) != data.GetType()) return;    
        StatusUpdate(data.status);
        UpdateMove(data.move);
        UpdateScore(data.score);
        UpdateGeneration(data.generation);
    }
    public void UpdateGeneration(int? value)
    {
        if (value == null) return;
        var root = document.rootVisualElement;
        var generationLabel = root.Q<Label>("GenerationText");
        generationLabel.text = $"Generation : {value}";
    }
    public void UpdateScore(int? value)
    {
        if (value == null) return;
        var root = document.rootVisualElement;
        var scoreLabel = root.Q<Label>("ScoreText");
        scoreLabel.text = $"Score : {value.ToString()}";
    }
    public void UpdateMove(int? value)
    {
        if (value == null) return;
        var root = document.rootVisualElement;
        var moveLabel = root.Q<Label>("MoveText");
        moveLabel.text = $"Starting Cells Remaining : {value.ToString()}";
    }
    public void StatusUpdate(string? value)
    {
        if (value == null) return;
        var root = document.rootVisualElement;
        var statusLabel = root.Q<Label>("StatusText");
        statusLabel.text = value.ToString();
    }
}
