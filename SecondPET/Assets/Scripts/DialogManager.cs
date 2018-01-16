using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogManager : MonoBehaviour {
    public Sprite[] Dialog;
    public Image contentDialog;
    public Transform Cristal;
    public Transform left, right;

    public int dialogCOunter;
    private bool inProgress;

    private void Start()
    {
        StartCoroutine(transition());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !inProgress)
        {
            if (dialogCOunter < 24)
            {
                dialogCOunter++;
                StartCoroutine(dialogViewer());
            }
            else
            {
                Application.LoadLevel(4);
            }
        }
    }

    public void skipDialog()
    {
        Application.LoadLevel(4);
    }

    private IEnumerator dialogViewer()
    {
        contentDialog.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        inProgress = true;
        float filler = 0;
        contentDialog.sprite = Dialog[dialogCOunter];
        yield return null;
        contentDialog.SetNativeSize();

        if (dialogCOunter != 21)
        {
            Tween upScale = contentDialog.GetComponent<Transform>().DOScale(0.7f, 1);
            //while (filler < 1.1)
            //{
            //    contentDialog.fillAmount = filler;
            //    yield return new WaitForSeconds(0.05f);
            //    filler += 0.05f;
            //}
            yield return upScale.WaitForCompletion();
            inProgress = false;
        }
        else
        {
            contentDialog.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            //Tween cristal = contentDialog.GetComponent<Transform>().DOScale(0.7f, 1.5f);
            //yield return cristal.WaitForCompletion();
            Tween cristal = Cristal.DOScale(0.4f, 1.5f);
            yield return cristal.WaitForCompletion();
            yield return new WaitForSeconds(4);
            Cristal.localScale = new Vector3(0, 0, 1);
            contentDialog.GetComponent<Transform>().localScale = new Vector3(0.7f, 0.7f, 1);
            dialogCOunter++;
            StartCoroutine(dialogViewer());
        }
    }

    IEnumerator transition()
    {
        yield return null;
        Tween leftM = left.DOMoveX(-12.87f, 2);
        right.DOMoveX(9.45f, 2);
        yield return leftM.WaitForCompletion();
        dialogCOunter = 0;
        StartCoroutine(dialogViewer());
    }
}
