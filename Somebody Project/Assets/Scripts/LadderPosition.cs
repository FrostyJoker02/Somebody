using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderPosition : MonoBehaviour
{
    
    public Vector3 pos;

    void Start()
    {   
        pos = transform.position;
        Debug.Log( "Ladder position is x = " + pos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
