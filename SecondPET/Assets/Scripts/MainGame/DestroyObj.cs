using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        StartCoroutine(destroyMe());
	}
	
    IEnumerator destroyMe()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
