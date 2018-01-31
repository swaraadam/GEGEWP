using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laut : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float maxY;
    float rSpeed;
    Transform thisPos;

	// Use this for initialization
	void Start () {
        thisPos = transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y >= maxY)
        {
            Debug.Log(transform.position);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);
        }
        else
        {

            transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
    }
}
