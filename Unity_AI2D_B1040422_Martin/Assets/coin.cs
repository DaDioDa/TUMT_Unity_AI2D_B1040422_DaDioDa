using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public npc coincount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("123");
            coincount.coinnum += 1;
            Destroy(this.gameObject);
        }
    }
}
