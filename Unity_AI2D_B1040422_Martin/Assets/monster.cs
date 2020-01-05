using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    Rigidbody2D rig;
    public float speed;
    public GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        move();
    }

    void move()
    {
        rig.AddForce(-transform.right * speed);
        RaycastHit2D hit = Physics2D.Raycast(head.transform.position, -head.transform.right, 0.4f,1<<8);
        if(hit == true)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawRay(head.transform.position, -head.transform.right*0.4f);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerctrl>().damage();
        }
    }

    public void kill()
    {
        Destroy(this.gameObject);
    }
}
