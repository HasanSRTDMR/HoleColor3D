using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DeathZone : MonoBehaviour
{
    [SerializeField] UIManager uI;
    [SerializeField] GameControler gameControler;

    private void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Object")
        {
            Destroy(collision.gameObject);

           uI.FillProgress();

            if (Game.isWin)
            {
                uI.PlayParticle();
                gameControler.WinGame();
                Game.isWin = false;
            }

        }

        if (collision.gameObject.tag=="Obstacle")
        {
            Destroy(collision.gameObject);
            Game.isGameOver = true;
            Camera.main.transform.DOShakePosition(1.0f, 0.2f, 20, 90.0f).OnComplete(() => { uI.GameOver(); });

        }
        
    }
}
