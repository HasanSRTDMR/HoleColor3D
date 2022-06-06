using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{

    [SerializeField] TMP_Text nextLevelText;
    [SerializeField] TMP_Text currentLevelText;
    [SerializeField] TMP_Text goldText;
    [SerializeField] Image progress;
    [SerializeField] GameObject swipe;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameControler gameControler;
    [SerializeField] ParticleSystem particle;
    
    float objectCount,objectValue;
    float fillValue;

    // Start is called before the first frame update
    void Start()
    {
        swipe.SetActive(true);
        goldText.text = Preferences.GoldReadValue().ToString();
        objectCount = (GameObject.FindGameObjectsWithTag("Object").Length);
        objectValue = objectCount;
        fillValue = 0.0f;
        progress.fillAmount = 0.0f;
        currentLevelText.text = (gameControler.currentSceneIndex + 1).ToString();
        nextLevelText.text = (gameControler.currentSceneIndex + 2).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        SwipeControl();
       
    }
    public void FillProgress()
    {
        fillValue += (1 / objectCount);
        progress.DOFillAmount(fillValue, 0.4f);        
        if (objectValue==1)
        {
            Game.isWin = true;
        }        
        objectValue--;
    }
    void SwipeControl()
    {
        if (Game.isMoving)
        {
            swipe.SetActive(false);
        }
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
    }
    public void PlayParticle()
    {
        particle.Play();
    }
}
