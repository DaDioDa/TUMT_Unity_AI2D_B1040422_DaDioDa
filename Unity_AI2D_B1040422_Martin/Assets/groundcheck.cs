using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    public playerctrl player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ground")
        {
            player.isground = true;
        }
        if(collision.tag == "monster")
        {
            collision.GetComponent<monster>().kill();
        }
    }
}
