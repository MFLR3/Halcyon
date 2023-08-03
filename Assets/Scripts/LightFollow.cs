using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    GameObject player;
    public GameObject light;
    Transform lightTrans;

    Vector3 playerPos;
    Transform playerTrans;
    Vector3 lightPos;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");

        playerTrans = player.transform;
        playerPos = playerTrans.position;

        lightTrans = light.transform;
        lightPos = playerPos;

        lightTrans.position = new Vector3(playerPos.x, 4f, playerPos.z + 2f);        
    }
}
