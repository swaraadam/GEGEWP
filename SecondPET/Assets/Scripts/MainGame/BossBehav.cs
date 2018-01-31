using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BossBehav : MonoBehaviour {

    private Animator animator;
    public int bossAnim;
    private Vector3 initPos, shieldPos;
    [SerializeField]
    private Transform shield;
    [SerializeField] Sprite one, two, three, four, five;

    public Image barHealth;
    public bool isShieldGone;
    public GameObject firePrefab;
    public int bossLife;


	// Use this for initialization
	void Start () {
        //mirroring camera
        Matrix4x4 mat = Camera.main.projectionMatrix;
        mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
        Camera.main.projectionMatrix = mat;

        //init
        isShieldGone = false;
        bossLife = 5;
        shieldPos = shield.localPosition;
        initPos = transform.position;
        animator = GetComponent<Animator>();
        StartCoroutine(justDoIt());
	}

    private void FixedUpdate()
    {
        animator.SetInteger("BossAnim", bossAnim);
        switch (bossLife)
        {
            case 5:
                {
                    barHealth.sprite = one;
                    break;
                }
            case 4:
                {
                    barHealth.sprite = two;
                    break;
                }
            case 3:
                {
                    barHealth.sprite = three;
                    break;
                }
            case 2:
                {
                    barHealth.sprite = four;
                    break;
                }
            case 1:
                {
                    barHealth.sprite = five;
                    Application.LoadLevel(4);
                    break;
                }
        }
    }

    IEnumerator justDoIt()
    {
        int loop = 0;
        while (loop < 5)
        {
            bossAnim = 0;
            shield.DORotate(new Vector3(0, 0, Random.Range(1, 180)), 4);
            Tween moveRandom = transform.DOMove(new Vector3(Random.Range(transform.position.x - 2f, transform.position.x + 1.5f), Random.Range(transform.position.y - 2.2f, transform.position.y + 1.5f), transform.position.z), 1);
            yield return moveRandom.WaitForCompletion();
            Tween moveBack = transform.DOMove(initPos, 1);
            yield return moveBack.WaitForCompletion();
            loop++;
        }
        //Transition
        bossAnim = 1;
        yield return new WaitForSeconds(1);
        shield.DOScale(0.1f, 2.5f);
        shield.DORotate(new Vector3(0, 0, 300), 2.5f);
        Tween trans = shield.DOMove(new Vector3(shield.position.x + 1.25f,shield.position.y+0.7f,0), 2.5f);
        yield return trans.WaitForCompletion();
        //Jurus
        Tween moveUp = transform.DOMoveY(transform.position.y + 15f, 2);
        yield return moveUp.WaitForCompletion();
        shield.DOScale(1f, 0.1f);
        shield.DOLocalMove(shieldPos, 0.1f);
        GameObject fireBall = Instantiate(firePrefab, transform.position, Quaternion.Euler(0,0,-225f));
        yield return new WaitForSeconds(3);
        shield.GetComponent<SpriteRenderer>().enabled = false;
        Tween moveDown = transform.DOMove(initPos, 2f);
        yield return moveDown.WaitForCompletion();
        isShieldGone = true;
        yield return new WaitForSeconds(2.5f);
        isShieldGone = false;
        shield.GetComponent<SpriteRenderer>().enabled = true;

        StartCoroutine(justDoIt());
    }
	
}
