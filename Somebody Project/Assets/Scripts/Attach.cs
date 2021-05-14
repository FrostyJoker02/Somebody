using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    private PlayerMovement player_script;
    public GameObject player;

    void Start()
    {
        player_script = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player && player_script.isGrounded)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
