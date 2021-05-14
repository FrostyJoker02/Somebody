using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumble : MonoBehaviour
{

    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("HurtBox")){
        FunctionTimer.Create(() => Destroy(this.gameObject), 1f );
        }
    }
}
