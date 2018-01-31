using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBehav : MonoBehaviour {

    public Transform gameOverBox;
    public SpriteRenderer gerobakBelakang;
    public Sprite grbkIsi, grbkKosong;
    public AudioSource AS;
    public AudioClip gameOver, pendDapet;
    public GameObject endAnim, scratch;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "powerUp")
        {
            FindObjectOfType<MoveOnPath>().Speed = 7f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            AS.PlayOneShot(gameOver);
            GameOver();
        }

        if (collision.transform.tag == "Civil")
        {
            AS.PlayOneShot(pendDapet);
            Destroy(collision.gameObject);
            gerobakBelakang.sprite = grbkIsi;
            gerobakBelakang.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "powerUp")
        {
            FindObjectOfType<MoveOnPath>().Speed = 3;
        }
    }


    public void GameOver()
    {
        if (Application.loadedLevel != 7)
        {
            FindObjectOfType<MoveOnPath>().enabled = false;
        }
        FindObjectOfType<WeaponFire>().enabled = false;
        StartCoroutine(scaleGameOver());
    }

    IEnumerator scaleGameOver()
    {
        if (Application.loadedLevel == 7)
        {
            Instantiate(scratch, transform.position, Quaternion.identity);
            Application.LoadLevel(4);
        }
        else
        {

            if (FindObjectOfType<GameOverController>().isFinish)
            {
                gerobakBelakang.GetComponent<Animator>().enabled = false;
                gerobakBelakang.sprite = grbkKosong;
                endAnim.SetActive(true);
                Debug.Log(gerobakBelakang.sprite);
                yield return new WaitForSeconds(2.5f);
                endAnim.SetActive(false);
            }
            else
            {
                yield return null;
            }
            Tween GOB = gameOverBox.DOScale(0.5f, 1.5f);
        }

    }


}
