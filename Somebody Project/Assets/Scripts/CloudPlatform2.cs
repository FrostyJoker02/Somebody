using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPlatform2 : MonoBehaviour
{
    private PlayerMovement player_script;
    public GameObject player;

    void Start()
    {
        player_script = player.GetComponent<PlayerMovement>();
        
    }

    void OnTriggerStay()
    { 
        if(Input.GetButton("Jump"))
        {
        player_script.jumpHeight = 10f;
        player_script.velocity.y = Mathf.Sqrt(player_script.jumpHeight * -2 * player_script.gravity);
        }
    }

    void OnTriggerExit()
    {
        player_script.jumpHeight = 3f;
    }
}
