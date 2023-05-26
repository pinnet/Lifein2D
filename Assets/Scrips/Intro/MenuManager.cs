using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    [SerializeField] UIDocument document;
    private void Awake()
    {
        var root = document.rootVisualElement;
        var aboutBox = root.Q<VisualElement>("Aboutbox");
        var startButton = root.Q<Button>("Start");
        var aboutButton = root.Q<Button>("About");


        aboutButton.clicked += () => { aboutBox.ToggleInClassList("hidden"); };
        startButton.clicked += () => { LoadStartScene(); };

    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Main");
    }
}
