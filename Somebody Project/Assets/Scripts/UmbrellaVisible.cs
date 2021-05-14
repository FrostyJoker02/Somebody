using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaVisible : MonoBehaviour
{
    SpriteRenderer renderer;

    public GameObject player;
    private PlayerMovement player_script;

    void Start()
    {
        player_script = player.GetComponent<PlayerMovement>();
        
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(player_script.usingUmbrella)
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
    }
}
