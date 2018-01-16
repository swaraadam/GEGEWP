using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : MonoBehaviour {


    public Sprite[] loadingBar, percentageBar;
    public SpriteRenderer bar, percentage;

	// Use this for initialization
	void Start () {
        StartCoroutine(loadingScene(1.2f, 5));
    }
	
    IEnumerator loadingScene(float time, int iteration)
    {
        yield return new WaitForSeconds(time);
        if (iteration > 0)
        {
            iteration = iteration - 1;
            time = time - 0.2f;
            bar.sprite = loadingBar[iteration];
            percentage.sprite = percentageBar[iteration];
            StartCoroutine(loadingScene(time, iteration));
        }
        else
        {
            Application.LoadLevel(1);
        }
    }
}
