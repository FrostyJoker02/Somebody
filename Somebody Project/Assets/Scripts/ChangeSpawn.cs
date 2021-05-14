using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpawn : MonoBehaviour
{
    public bool isRp = false;
    public SpriteRenderer rend;
    public Sprite newSprite;
    public Sprite oldSprite;

    void OnTriggerEnter(Collider other)
    {
        Respawn.respawnPoint = this.transform;
        isRp = true;
    }

    void Update()
    {
        if(Respawn.respawnPoint != this.transform)
        {
            isRp = false;
        }

        if(isRp)
        {
            rend.sprite = newSprite;
        }
        else
        {
            rend.sprite = oldSprite;
        }
    }
}
