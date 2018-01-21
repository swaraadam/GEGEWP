using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jombieBehav : MonoBehaviour {

    public GameObject scratch;

    // Use this for initialization
    void Start () {
        StartCoroutine(hit());
    }

    IEnumerator hit()
    {
        yield return new WaitForSeconds(2.3f);
        GameObject cakar = Instantiate(scratch, transform.position + new Vector3(3.5f, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Destroy(cakar.gameObject);
        yield return new WaitForSeconds(0.4f);
        FindObjectOfType<PlayerBehav>().GameOver();
    }
}
