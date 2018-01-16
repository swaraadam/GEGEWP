using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    public int Coin, Star;
    public Text CoinTXT, StarTXT;
    public Image BGpause, TXTpause;

    private bool isPaused;

	// Update is called once per frame
	void Update () {
        CoinTXT.text = Coin.ToString();
        StarTXT.text = Star.ToString();
        if (Coin != PlayerPrefs.GetInt("Coin"))
        {
            Coin = PlayerPrefs.GetInt("Coin");
        }

        if (Star != PlayerPrefs.GetInt("Star"))
        {
            Star = PlayerPrefs.GetInt("Star");
        }
    }


    public void PauseBTN()
    {
        if (!isPaused)
        {
            StartCoroutine(moveXimage(0, BGpause.transform,0));
            StartCoroutine(moveXimage(0, TXTpause.transform,0));
            isPaused = true;
        }
        else if (isPaused)
        {
            StartCoroutine(moveXimage(-1377, BGpause.transform,1));
            StartCoroutine(moveXimage(1377, TXTpause.transform,1));
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    IEnumerator moveXimage(float x, Transform target,int ts)
    {
        Tween wait = target.DOLocalMoveX(x, 0.8f);
        yield return wait.WaitForCompletion();
        Time.timeScale = ts;
    }

    public void backToMenu()
    {
        Application.LoadLevel(4);
    }
}
