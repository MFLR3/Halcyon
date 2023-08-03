using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    // Set a bounds size - Preferably to fit horizontal mobile screen size
    public GameObject image;
    NodeGenerator nodeGen;
    [SerializeField] GameObject generator;
    int x;
    int z; 
    public Vector3 startPos;
    Vector3 nodeVec;
    Vector3 imageVec;
    public GameObject node;
    float xPos;
    float zPos;

    void Awake()
    {
        nodeGen = generator.GetComponent<NodeGenerator>();
    }

    void Start()
    {
        x = nodeGen.mazeXAmount;
        z = nodeGen.mazeZAmount;
    }

    void Update()
    {
        nodeVec = node.GetComponent<MeshRenderer>().bounds.size;
        imageVec = image.GetComponent<MeshCollider>().bounds.size;
        float xOffset = (imageVec.x - x) / 2;
        float zOffset = (imageVec.z - z) / 2;

        xPos = nodeVec.x / 2;
        zPos = nodeVec.z / 2;
       
        startPos = new Vector3(xPos + xOffset,0,zPos + zOffset);
        transform.position = startPos;
    }
}