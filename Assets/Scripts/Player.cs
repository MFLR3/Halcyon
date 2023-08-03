using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // Get generator object to access generator script
    [SerializeField] GameObject playerPrefab;
    public float xOffset;
    public float zOffset;
    public Vector3 vecRand;

    void Start()
    {         
        // Randomised Vector3 for Player start pos
        System.Random rand = new System.Random();

        int randX = rand.Next(1,4);
        int randZ = rand.Next(1,4);

        vecRand = new Vector3(xOffset + randX, 0.8f, zOffset + randZ); 
        Instantiate(playerPrefab, new Vector3(vecRand.x, 0.8f, vecRand.z), Quaternion.identity);
    }   

}