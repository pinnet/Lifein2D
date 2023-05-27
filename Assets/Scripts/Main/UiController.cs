using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class UiController : MonoBehaviour
{
    [SerializeField] UIDocument document;

    public void UpdateScore(int value)
    {
        var root = document.rootVisualElement;
        var scoreLabel = root.Q<Label>("ScoreText");
        scoreLabel.text = $"Score: {value.ToString()}";
    }
    public void UpdateMove(int value)
    {
        var root = document.rootVisualElement;
        var moveLabel = root.Q<Label>("MoveText");
        moveLabel.text = $"Move: {value.ToString()}";
    }
    public void StatusUpdate(string value)
    {
        var root = document.rootVisualElement;
        var statusLabel = root.Q<Label>("StatusText");
        statusLabel.text = value.ToString();
    }
}
