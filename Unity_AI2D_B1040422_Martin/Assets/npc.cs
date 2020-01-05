using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc : MonoBehaviour
{
    public string saystart;
    public string sayunclear;
    public string sayclear;
    public GameObject gameover;
    public enum state
    {
        start,unclear,clear
    }
    public GameObject dlog;
    public Text text;
    public state _state;
    public int coinnum;
    public int coinfinish = 6;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Say();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Leave();
        }
    }
    void Say()
    {
        dlog.SetActive(true);
        StopAllCoroutines();

        if (coinnum == coinfinish)
        {
            gameover.SetActive(true);
        }

        switch (_state)
        {
            case state.start:
                StartCoroutine(ShowDlog(saystart));
                _state = state.unclear;
                break;
            case state.unclear:
                StartCoroutine(ShowDlog(sayunclear));
                break;
            case state.clear:             
                StartCoroutine(ShowDlog(sayclear));
                break;
        }
    }
    void Leave()
    {
        dlog.SetActive(false);
        StopAllCoroutines();
    }

    private IEnumerator ShowDlog(string say)
    {
        text.text = "";
        for (int i = 0; i< say.Length; i++)
        {
            text.text += say[i].ToString();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
