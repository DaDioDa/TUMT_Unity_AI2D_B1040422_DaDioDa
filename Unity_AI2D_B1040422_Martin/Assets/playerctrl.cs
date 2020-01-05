using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerctrl : MonoBehaviour
{
    Rigidbody2D rig;
    Vector2 playerpos;
    public float speed;
    public float jumpp;
    public bool isground = true;
    Animator ani;
    public float hpmax = 3;
    public float hp = 3;
    public Image hpbar;
    public GameObject gameover;

    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void Update()
    {
        jump();
    }

    void move()
    {
        playerpos = new Vector2(Input.GetAxisRaw("Horizontal")*speed,0);
        rig.AddForce(playerpos);
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            ani.SetBool("walking", true);
        }
        else
        {
            ani.SetBool("walking", false);
        }
        if ((Input.GetAxisRaw("Horizontal") > 0))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if((Input.GetAxisRaw("Horizontal") < 0))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
    }

    void jump()
    {
        if (Input.GetButtonDown("Jump")&&isground == true)
        {
            rig.AddForce(new Vector2(0,jumpp));
            isground = false;
        }
    }

    public void damage()
    {
        hp = hp - 1;
        hpbar.fillAmount = hp / hpmax;    
        if(hp <= 0)
        {
            gameover.SetActive(true);
        }
    }
}
