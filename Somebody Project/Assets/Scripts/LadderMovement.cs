using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    
    public bool isLadder;
    public Transform ladderCheck;
    public float ladderDistance = 0.1f;
    public LayerMask ladderMask;
    public GameObject player;
    private PlayerMovement player_script;
    public float ladderSpeed = 3f;

    void Start()
    {
        player_script = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        isLadder = Physics.CheckSphere(ladderCheck.position, ladderDistance, ladderMask);
        
   

        if(Input.GetButton("Up") && isLadder)
        {
            Vector3 move = new Vector3(0f, 2f, 0f);
            player_script.gravity = 0f;
            player_script.jumpHeight = 0f;
            player_script.fallMultiplier = 0f;
            player_script.lowJumpMultiplier = 0f;
            player_script.controller.Move(move * ladderSpeed * Time.deltaTime);
        }

        if(Input.GetButton("Down") && isLadder)
        {
            Vector3 move = new Vector3(0f, -2f, 0f);
            player_script.controller.Move(move * ladderSpeed * Time.deltaTime);

        }

        if(Input.GetButton("Jump")){
            player_script.gravity = -9.81f;
            player_script.jumpHeight = 3f;
            player_script.fallMultiplier = 2.5f;
            player_script.lowJumpMultiplier = 2f;
        }

        if((isLadder == false))
        {
            player_script.gravity = -9.81f;
            player_script.jumpHeight = 3f;
            player_script.fallMultiplier = 2.5f;
            player_script.lowJumpMultiplier = 2f;
           
        }
    }
}
