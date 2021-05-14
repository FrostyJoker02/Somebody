using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaPickUp : MonoBehaviour
{
    private PlayerMovement player_script;
    public GameObject player;

    void Start()
    {
        player_script = player.GetComponent<PlayerMovement>();  
    }

    void OnTriggerEnter()
    {
        player_script.isUmbrella = true;
        Destroy(gameObject);
    }
    

    
}
