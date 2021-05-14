using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private PlayerMovement player_script;
    public GameObject player;

    void Start()
    {
        player_script = player.GetComponent<PlayerMovement>();
    }

    
    void OnTriggerEnter()
    {
        if(player_script.isUmbrella)
        {
            player_script.velocity.y = Mathf.Sqrt(player_script.jumpHeight * -2 * player_script.gravity);
        }
    }
}
