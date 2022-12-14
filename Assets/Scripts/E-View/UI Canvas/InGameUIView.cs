using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class InGameUIView : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI scoreText;
    
    [Inject] private ISessionPresenter _sessionPresenter;

    [SerializeField] 
    private GameObject MainMenu;
    
    [SerializeField] 
    private GameObject player;
    private void Start()
    {
        _sessionPresenter.scoreRx.Subscribe(score => scoreText.text = "Score : " + score.ToString()).AddTo(this);
    }

    public void ShowMenMenu()
    {
        gameObject.SetActive(false);
        player.SetActive(false);
        MainMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
