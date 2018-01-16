using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    SpriteRenderer mySelf;
    public Transform buttonPlay;

    private void Start()
    {
        StartCoroutine(FadeIn(0.2f,0));
        mySelf = GetComponent<SpriteRenderer>();
    }


    IEnumerator FadeIn(float time, float alpha)
    {
        yield return new WaitForSeconds(time);
        mySelf.color = new Color(255, 255, 255, alpha);
        if (alpha < 0.5f)
        {
            alpha = alpha + 0.05f;
            StartCoroutine(FadeIn(time, alpha));
        }
        else
        {
            Debug.Log("in");
            buttonPlay.DOMoveX(950, 2);
        }
        Debug.Log(alpha);
    }

    public void playButton()
    {
        Application.LoadLevel(2);
    }
}
