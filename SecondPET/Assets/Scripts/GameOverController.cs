using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public Text star, coin;
    public Sprite starBlue, starRed, starBluef, starRedf, bgBlue, bgRed, okRed, okBlue;
    public Image star1, star2, star3, star1F, star2F, star3F, background, ok;
    public bool isFinish;

	// Update is called once per frame
	void Update () {

        coin.text = FindObjectOfType<GameManager>().Coin.ToString();
        if (!isFinish)
        {
            star1.sprite = starRed;
            star2.sprite = starRed;
            star3.sprite = starRed;
            star1F.sprite = starRedf;
            star2F.sprite = starRedf;
            star3F.sprite = starRedf;
            background.sprite = bgRed;
            ok.sprite = okRed;
            coin.text = FindObjectOfType<GameManager>().Coin.ToString();
        }
        else
        {
            star1.sprite = starBlue;
            star2.sprite = starBlue;
            star3.sprite = starBlue;
            star1F.sprite = starBluef;
            star2F.sprite = starBluef;
            star3F.sprite = starBluef;
            background.sprite = bgBlue;
            ok.sprite = okBlue;
            coin.text = FindObjectOfType<GameManager>().Coin.ToString();
        }
	}
}
