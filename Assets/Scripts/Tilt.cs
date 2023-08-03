using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    private GameObject playerObject;
    private Rigidbody rigid;
    Vector3 playerPos; 
        
    private void FixedUpdate(){
        playerObject = GameObject.FindWithTag("Player"); 
        rigid = playerObject.GetComponent<Rigidbody>();  

        Vector3 tiltObject = Input.acceleration;        
        tiltObject = Quaternion.Euler(90,0,0) * tiltObject;
        rigid.AddForce(tiltObject.x * 8, 0, tiltObject.z * 8); 
    }
}