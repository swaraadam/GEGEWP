using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossBehav : MonoBehaviour {

    enum bossCondition
    {
        idle,
        transIJ,
        jurus,
        transJA,
        attacked,
        transAI
    }

    private Animator animator;
    private int bossAnim;
    private Vector3 initPos, shieldPos;
    [SerializeField]
    private Transform shield;

    public GameObject firePrefab;

	// Use this for initialization
	void Start () {
        //mirroring camera
        Matrix4x4 mat = Camera.main.projectionMatrix;
        mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
        Camera.main.projectionMatrix = mat;

        //init
        shieldPos = shield.localPosition;
        initPos = transform.position;
        animator = GetComponent<Animator>();
        StartCoroutine(justDoIt());
	}
    IEnumerator justDoIt()
    {
        int loop = 0;
        while (loop < 5)
        {
            bossAnim = 0;
            animator.SetInteger("BossAnim", bossAnim);
            shield.DORotate(new Vector3(0, 0, Random.Range(1, 180)), 4);
            Tween moveRandom = transform.DOMove(new Vector3(Random.Range(transform.position.x - 2f, transform.position.x + 1.5f), Random.Range(transform.position.y - 2.2f, transform.position.y + 1.5f), transform.position.z), 2);
            yield return moveRandom.WaitForCompletion();
            Tween moveBack = transform.DOMove(initPos, 2);
            yield return moveBack.WaitForCompletion();
            loop++;
        }
        //Transition
        bossAnim = 1;
        animator.SetInteger("BossAnim", bossAnim);
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
        GameObject fireBall = Instantiate(firePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        shield.GetComponent<SpriteRenderer>().enabled = false;
        Tween moveDown = transform.DOMove(initPos, 2f);
        yield return moveDown.WaitForCompletion();

        yield return new WaitForSeconds(3f);
        shield.GetComponent<SpriteRenderer>().enabled = true;

        StartCoroutine(justDoIt());
    }
	
}
