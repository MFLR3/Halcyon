using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image : MonoBehaviour
{
    Vector3 imageVec;
    Vector3 startPos;
    float xPos;
    float zPos;

    void Update()
    {
        imageVec = GetComponent<MeshRenderer>().bounds.size;

        xPos = imageVec.x / 2;
        zPos = imageVec.z / 2;

        startPos = new Vector3(xPos,0,zPos);
        transform.position = startPos;
    }
}



