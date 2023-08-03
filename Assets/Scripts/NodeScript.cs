using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public GameObject[] walls;        

    // Method to remove wall, identified by number in walls array.
    public void deleteWall(int num){
        Destroy(walls[num - 1]);
    }     

}