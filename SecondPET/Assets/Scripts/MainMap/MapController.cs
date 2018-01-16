using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MapController : MonoBehaviour {

    public Transform sliderButton, achievment, shop, coin, star, achievmentPage, itemPage, chapterPage, quitPage;
    bool isAchievment, isItem, isChapter, isQuit;
    public AudioSource AS;
    public AudioClip buttonClicked;
    public Text score;

	// Use this for initialization
	void Start () {
        StartCoroutine(tweenButton(sliderButton, -588, 0, 1.5f));
        StartCoroutine(tweenButton(coin, 497, 321, 1.5f));
        StartCoroutine(tweenButton(star, 324, 321, 1.5f));
        StartCoroutine(tweenButton(achievment, 152, -309, 1.5f));
        StartCoroutine(tweenButton(shop, 463, -309, 1.5f));
        score.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isAchievment)
            {
                StartCoroutine(achievmentOpen(0f));
                isAchievment = false;
            }
            if (isItem)
            {
                StartCoroutine(itemOpen(0f));
                isItem = false;
            }
            if (isChapter)
            {
                StartCoroutine(chapterOpen(0f));
                isChapter = false;
            }
            if (isQuit)
            {
                StartCoroutine(quitOpen(0f));
                isQuit = false;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            StartCoroutine(quitOpen(0.4f));
        }
    }

    IEnumerator tweenButton(Transform transformTarget, float x, float y, float time)
    {
        yield return null;
        Vector3 targetPosition = new Vector3(x, y, 1);
        Tween DoTween = transformTarget.DOLocalMove(targetPosition, time);
    }

    public void yesIWantQuit()
    {
        Application.Quit();
    }

    public void level1Selected()
    {
        Application.LoadLevel(5);
    }

    public void ButtonKu(int i)
    {
        if (i == 1)
        {
            StartCoroutine(achievmentOpen(0.4f));
        }else if (i == 2)
        {
            StartCoroutine(itemOpen(0.5f));
        }else if (i == 4)
        {
            StartCoroutine(chapterOpen(0.4f));
        }
    }

    public void movie()
    {
        Application.LoadLevel(2);
    }

    IEnumerator achievmentOpen(float scale)
    {
        //itemPage.localScale = new Vector3(0, 0, 0);
        AS.PlayOneShot(buttonClicked);
        yield return null;
        achievmentPage.DOScale(scale, 0.2f);
        isAchievment = true;
    }

    IEnumerator itemOpen(float scale)
    {
        //achievmentPage.localScale = new Vector3(0, 0, 0);
        AS.PlayOneShot(buttonClicked);
        yield return null;
        itemPage.DOScale(scale, 0.2f);
        isItem = true;
    }

    IEnumerator quitOpen(float scale)
    {
        //achievmentPage.localScale = new Vector3(0, 0, 0);
        AS.PlayOneShot(buttonClicked);
        yield return null;
        quitPage.DOScale(scale, 0.2f);
        isQuit = true;
    }

    IEnumerator chapterOpen(float scale)
    {
        AS.PlayOneShot(buttonClicked);
        yield return null;
        chapterPage.DOScale(scale, 0.2f);
        isChapter = true;
    }
}
