using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    Button button;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnQuitPressed);
    }

    void OnQuitPressed()
    {
        print("Quitting game...");
        Application.Quit();
    }
}
