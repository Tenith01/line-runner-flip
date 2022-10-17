using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameOverUIView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    
    [SerializeField]
    private TextMeshProUGUI currentScoreText;
    
    [Inject] private ISessionPresenter _sessionPresenter;

    private int score;

    private void Start()
    {
        _sessionPresenter.scoreRx.Subscribe(score => currentScoreText.text = "Current Score : " + score.ToString()).AddTo(this);
        _sessionPresenter.scoreRx.Subscribe(score => this.score = score).AddTo(this);
        CheckHighScore();
    }

    private void CheckHighScore()
    {
        int highScore = PlayerPrefs.GetInt("highScore");
        if (highScore<score)
        {
            Debug.Log("higScore Added");
            AddkHighScore(score);
        }

        highScoreText.text ="High Score : "+  highScore;

    }

    private void AddkHighScore(int score)
    {
        PlayerPrefs.SetInt("highScore",score);
        PlayerPrefs.Save();
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        _sessionPresenter.SetScoreToZero();
    }
}
