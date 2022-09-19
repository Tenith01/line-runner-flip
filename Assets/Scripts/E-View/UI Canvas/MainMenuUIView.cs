using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIView : MonoBehaviour
{
    public void StartRunning()
    {
        SceneManager.LoadScene(0);
    }
}
