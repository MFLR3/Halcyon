using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    public GameObject water;

    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            water.SetActive(true);            
        }
    }
}
