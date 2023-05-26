using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    [SerializeField] UIDocument document;

    public void UpdateScore(int value)
    {
        var root = document.rootVisualElement;
        var scoreLabel = root.Q<Label>("ScoreText");
        scoreLabel.text = $"Score: {value.ToString()}";
    }
}
