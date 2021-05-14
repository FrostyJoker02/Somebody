using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public GameObject player;
    private PlayerStats player_script;
    public Transform respawnPoint = Respawn.respawnPoint;
    
    

    void Start()
    {
        player_script = player.GetComponent<PlayerStats>();
        
    }

    void Update()
    {

        respawnPoint = Respawn.respawnPoint;
        
        if (player_script.health <= 0)
        {
            player_script.health = 3;
            player_script.iFrames = 0;
            player.transform.position = respawnPoint.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.CompareTag("HurtBox"))
        {
            player_script.iFrames = player_script.iFrames - 1 * Time.deltaTime;

            if(player_script.iFrames <= 0)
            {
                player_script.iFrames = 2;
                player_script.health = player_script.health - 1;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("HurtBox"))
        {
            player_script.iFrames = 0;
        }
    }
}
