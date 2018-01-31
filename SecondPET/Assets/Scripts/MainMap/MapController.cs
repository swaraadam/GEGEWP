using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MapController : MonoBehaviour {

    public Transform sliderButton, achievment, shop, coin, star, achievmentPage, itemPage, chapterPage, quitPage;
    [SerializeField] Transform settingPage;
    bool isAchievment, isItem, isChapter, isQuit, isSetting;
    public AudioSource AS;
    public AudioClip buttonClicked;
    public Text score;

    RaycastHit2D Hit;
    public LayerMask mask;

    //tutorial map related
    [SerializeField] SpriteRenderer tutorHolder;
    [SerializeField] Sprite[] tutorImages;
    [SerializeField] GameObject UICanvas;

    int clickTutorial;
    int firstplay;
    bool isTutorial;

	// Use this for initialization
	void Start () {
        firstplay = PlayerPrefs.GetInt("tutormap");

        if (firstplay == 1)
            initializeMap();
        else
            MapTutorial();
    }

    void MapTutorial()
    {
        clickTutorial = 0;
        UICanvas.SetActive(false);
        PlayerPrefs.SetInt("tutormap", 0);
        isTutorial = true;
        tutorHolder.sprite = tutorImages[0];
    }

    void initializeMap()
    {
        StartCoroutine(tweenButton(sliderButton, -588, 0, 1.5f));
        StartCoroutine(tweenButton(coin, 497, 321, 1.5f));
        StartCoroutine(tweenButton(star, 324, 321, 1.5f));
        StartCoroutine(tweenButton(achievment, 152, -309, 1.5f));
        StartCoroutine(tweenButton(shop, 463, -309, 1.5f));
        score.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    private void Update()
    {
        if (isTutorial)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickTutorial++;
                if (clickTutorial == 1)
                    tutorHolder.sprite = tutorImages[clickTutorial];
                else
                {
                    tutorHolder.sprite = null;
                    PlayerPrefs.SetInt("tutormap", 1);
                    isTutorial = false;
                    UICanvas.SetActive(true);
                    initializeMap();
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && layerDetector())
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
                if (isSetting)
                {
                    StartCoroutine(settingOpen(0f));
                    isSetting = false;
                }
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            StartCoroutine(quitOpen(0.4f));
        }
    }

    private bool layerDetector()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Hit = Physics2D.GetRayIntersection(ray, 10, mask);
        if (Hit.collider.name == "GameObject")
        {
            return true;
        }
        else return false;
    }

    public void tutorialButton()
    {
        MapTutorial();
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

    public void openFanpage()
    {
        Application.OpenURL("https://www.facebook.com/CarbonDefender/");
    }

    public void level1Selected()
    {
        Debug.Log("level1");
        PlayerPrefs.SetInt("lvlID", 1);
        Application.LoadLevel(8);
    }
    public void level2Selected()
    {
        Debug.Log("level2");
        PlayerPrefs.SetInt("lvlID", 2);
        Application.LoadLevel(8);
    }
    public void level3Selected()
    {
        Debug.Log("level3");
        PlayerPrefs.SetInt("lvlID", 3);
        Application.LoadLevel(8);
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
        }else if (i == 5)
        {
            StartCoroutine(settingOpen(0.5f));
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
        itemPage.DOScaleX(scale+0.1f, 0.2f);
        itemPage.DOScaleY(scale, 0.2f);
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

    IEnumerator settingOpen(float scale)
    {
        AS.PlayOneShot(buttonClicked);
        yield return null;
        settingPage.DOScale(scale, 0.2f);
        isSetting = true;
    }
}
