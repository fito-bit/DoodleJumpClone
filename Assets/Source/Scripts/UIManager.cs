using DG.Tweening;
using Source.Scripts;
using Supyrb;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject loseUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject startUI;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text finalScoreTxt;

    private void Awake()
    {
        Signals.Get<SetScoreSignal>().AddListener(SetScore);
        Signals.Get<LoseSignal>().AddListener(Lose);
        Time.timeScale = 0;
    }

    void SetScore(int score)
    {
        scoreTxt.text = score.ToString();
    }

    public void Restart()
    {
        Signals.Clear();
        DOTween.Clear();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
        gameUI.SetActive(false);
        pauseUI.SetActive(true);
    }
    
    public void Play()
    {
        Time.timeScale = 1;
        Signals.Get<StartGameSignal>().Dispatch();
        startUI.SetActive(false);
        gameUI.SetActive(true);
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
    }

    void Lose()
    {
        finalScoreTxt.text = "Score: "+scoreTxt.text;
        gameUI.SetActive(false);
        loseUI.SetActive(true);
    }
}
