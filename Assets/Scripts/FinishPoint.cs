using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
             GameObject gm = GameObject.FindWithTag("GameController");
            //Debug.Log("got to lose");
            gm.GetComponent<GameManager>().Finish();
        }

    }
}
