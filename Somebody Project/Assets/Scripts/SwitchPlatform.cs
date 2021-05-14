using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatform : MonoBehaviour
{
    Collider m_Collider;
    MeshRenderer renderer;
    public bool startOff;

    public GameObject player;
    private PlayerMovement player_script;

    void Start()
    {
        

        player_script = player.GetComponent<PlayerMovement>();

        //Fetch the GameObject's Collider (make sure it has a Collider component)
        m_Collider = GetComponent<Collider>();
        renderer = GetComponent<MeshRenderer>();

        if (startOff)
        {
         m_Collider.enabled = !m_Collider.enabled;
            renderer.enabled = !renderer.enabled;
        }
    }

    

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && player_script.isGrounded)
        {
            FunctionTimer.Create(() => m_Collider.enabled = !m_Collider.enabled, 0.2f );
            FunctionTimer.Create(() => renderer.enabled = !renderer.enabled, 0.2f );
            
            
            Debug.Log("Collider.enabled = " + m_Collider.enabled);
        }
    }
}
