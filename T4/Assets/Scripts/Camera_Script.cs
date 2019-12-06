using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject follow;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;

        gameObject.transform.position = new Vector3(posX, posY, gameObject.transform.position.z);
    }
}
