using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Turtle target;
    private float damage = 2f;
    private float timerMax = 0.5f;
    private float timer;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bitch you hurt");
        if(collision.transform.CompareTag("Player"))
        {
            target =collision.transform.GetComponentInParent<Turtle>();
            target.TakeDamage(damage);
            timer = timerMax;
        }
    }
    void OnCollisionStay2D(Collision2D collision){
         if (timer <= 0){
             target.TakeDamage(damage);
             timer = timerMax;
         } else {
             timer -= Time.deltaTime;
         }
     }

}
