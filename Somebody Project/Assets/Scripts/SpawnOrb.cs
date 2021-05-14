using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrb : MonoBehaviour
{
    public GameObject jumpOrb;
    
    void Start()
    {
     FunctionTimer.Create(() => Instantiate(jumpOrb, transform.position, Quaternion.identity), 3f );   
    }

    
}
