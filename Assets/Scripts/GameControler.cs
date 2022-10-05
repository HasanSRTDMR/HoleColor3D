using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameControler : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] ScoreManager scoreManager;
    public int currentSceneIndex;
    private void Awake()
    {
       
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Game.isWin = false;
    }
  
    public void WinGame()
    {
        scoreManager.AddGold();
        Invoke("NextLevelScene",2.0f);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
        gameObject.SetActive(false);
    }
    void NextLevelScene()
    {
        
        SceneManager.LoadScene(currentSceneIndex+1);
    }
    public void StartAgain()
    {
        SceneManager.LoadScene(0);
    }

}
