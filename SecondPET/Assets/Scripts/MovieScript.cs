using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieScript : MonoBehaviour {


    public RawImage rawImage;
	// Use this for initialization
	void Start () {
        Handheld.PlayFullScreenMovie("Trailer.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
