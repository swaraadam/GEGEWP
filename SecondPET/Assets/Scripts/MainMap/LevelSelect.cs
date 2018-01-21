using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public Image One, Two, Three;
    public Sprite btnUnlocked, btnLocked;

	// Update is called once per frame
	void FixedUpdate () {
        switch (PlayerPrefs.GetInt("Level"))
        {
            case 1:
                {
                    One.sprite = btnUnlocked;
                    Two.sprite = btnLocked;
                    Three.sprite = btnLocked;

                    Two.GetComponent<Button>().enabled = false;
                    Three.GetComponent<Button>().enabled = false;
                    break;
                }
            case 2:
                {
                    One.sprite = btnUnlocked;
                    Two.sprite = btnUnlocked;
                    Three.sprite = btnLocked;

                    Two.GetComponent<Button>().enabled = true;
                    Three.GetComponent<Button>().enabled = false;
                    break;
                }
            case 3:
                {
                    One.sprite = btnUnlocked;
                    Two.sprite = btnUnlocked;
                    Three.sprite = btnUnlocked;

                    Two.GetComponent<Button>().enabled = true;
                    Three.GetComponent<Button>().enabled = true;
                    break;
                }
        }
	}
}
