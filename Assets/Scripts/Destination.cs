using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Destination : MonoBehaviour
{
    float xPos;
    float zPos;
    
    [SerializeField] GameObject destinationPrefab;
    Vector3 vecRand;

    [SerializeField] float xOffset;
    [SerializeField] float zOffset;   

    float xMaze;

    void Start()
    {   
        System.Random rand = new System.Random();

        int randX = rand.Next(5,8);
        int randZ = rand.Next(1,4);

        vecRand = new Vector3(xOffset + randX, 0.8f, zOffset + randZ); 

        Instantiate(destinationPrefab, new Vector3(vecRand.x, 0.1f, vecRand.z), Quaternion.identity);
        
    }   

} 