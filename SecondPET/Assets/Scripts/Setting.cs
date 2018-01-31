using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour {

    public Sprite on, off;
    public Image audio, reset;
    public AudioSource audioSource;

    bool isAudio, isReset;

    private void Start()
    {
        isAudio = true;
        isReset = false;
    }

    public void audioSetting()
    {
        if (isAudio)
        {
            audioSource.Pause();
            audio.sprite = off;
            isAudio = false;
        }else if (!isAudio)
        {
            audioSource.UnPause();
            audio.sprite = on;
            isAudio = true;
        }
    }

    public void resetSetting()
    {
        if (!isReset)
        {
            reset.sprite = on;
            isReset = true;
            PlayerPrefs.SetInt("Level", 1);
            StartCoroutine(resetBU());
        }
    }

    IEnumerator resetBU()
    {
        yield return new WaitForSeconds(2);
        isReset = false;
        reset.sprite = off;

    }
}
