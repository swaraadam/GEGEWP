using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcLoop : MonoBehaviour {
    
    [SerializeField] float xPos;
    [SerializeField] float speed;

    [SerializeField] float yMin, yMax;

    Transform thisPos;

    private void Awake()
    {
        thisPos = transform;
    }

    void Update () {
        transform.Translate(new Vector2(speed * Time.deltaTime,0));
        if (thisPos.position.x > xPos || thisPos.position.x < -xPos)
        {
            transform.position = new Vector3(thisPos.position.x * -1, Random.Range(yMin,yMax), thisPos.position.z);
        }
	}
}
