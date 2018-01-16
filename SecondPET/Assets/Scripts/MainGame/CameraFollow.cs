using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Target;

    private void FixedUpdate()
    {
        transform.position = new Vector3(Target.transform.position.x, -2.4f, -10);
    }
}
