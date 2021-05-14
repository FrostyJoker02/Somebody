using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraJumpObject : MonoBehaviour
{
    public GameObject spawnOrb;
    public Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("HurtBox"))
        {
        PlayerMovement.extraJumps += 1;
        Instantiate(spawnOrb, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        }
    }
}
