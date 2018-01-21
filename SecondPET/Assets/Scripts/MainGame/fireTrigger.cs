using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireTrigger : MonoBehaviour {

    public GameObject triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "bunder")
        {
            triggered.GetComponent<fireLvl2>().enabled = true;
            Destroy(gameObject);
        }
    }
}
