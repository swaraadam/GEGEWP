using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVIETEST : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Handheld.PlayFullScreenMovie("Video.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MovieEnd");
            Application.LoadLevel(3);
        }
    }
}
