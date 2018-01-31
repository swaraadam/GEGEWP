using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public SpriteRenderer ttrl;
    public Sprite[] tutorial;

    private int count = 0;
	// Use this for initialization
	void Start () {
        count = 1;
        if (PlayerPrefs.GetInt("lvlID") == 1)
        {
            ttrl.sprite = tutorial[0];
        }else if(PlayerPrefs.GetInt("lvlID") == 2)
        {
            ttrl.sprite = tutorial[2];
        }
        else if (PlayerPrefs.GetInt("lvlID") == 3)
        {
            ttrl.sprite = tutorial[5];
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
        }

        if (PlayerPrefs.GetInt("lvlID") == 1 && count == 2)
        {
            ttrl.sprite = tutorial[1];
        }
        else if (PlayerPrefs.GetInt("lvlID") == 1 && count > 2)
        {
            Application.LoadLevel(5);
        }

        if (PlayerPrefs.GetInt("lvlID") == 2 && count == 2)
        {
            ttrl.sprite = tutorial[3];
        }else if(PlayerPrefs.GetInt("lvlID") == 2 && count == 3)
        {
            ttrl.sprite = tutorial[4];
        }
        else if (PlayerPrefs.GetInt("lvlID") == 2 && count > 3)
        {
            Application.LoadLevel(6);
        }

        if (PlayerPrefs.GetInt("lvlID") == 3 && count>1)
        {
            Application.LoadLevel(7);
        }
    }
}
