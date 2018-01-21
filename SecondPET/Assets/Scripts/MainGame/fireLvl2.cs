using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireLvl2 : MonoBehaviour {

    public GameObject target, jombi;
    public SpriteRenderer gerobakBelakang;
    public Sprite boom, grbkKosong;

    private void Start()
    {
        if (Application.loadedLevel == 7)
        {
            target = GameObject.Find("Kereta");
        }
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.25f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Kereta")
        {
            GetComponent<SpriteRenderer>().sprite = boom;
            if (Application.loadedLevel == 6)
            {
                gerobakBelakang.sprite = grbkKosong;
                gerobakBelakang.GetComponent<Animator>().enabled = false;
            }
            StartCoroutine(baam());
        }
    }

    IEnumerator baam()
    {
        yield return new WaitForSeconds(0.15f);
        GameObject jomby = Instantiate(jombi, target.transform.position+new Vector3(0,1,0), Quaternion.identity);
        jomby.transform.parent = target.transform;
        Destroy(gameObject);
    }
}
