using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ampas : MonoBehaviour
{

    [SerializeField] float xPos;
    [SerializeField] float speed;


    Transform thisPos;

    private void Awake()
    {
        thisPos = transform;
    }

    void Update()
    {
        transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        if (thisPos.position.x > xPos)
        {
            transform.position = new Vector3((this.GetComponent<SpriteRenderer>().sprite.bounds.extents.x) * -4.884f, thisPos.position.y, thisPos.position.z);
        }
    }
}
