using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plankton : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<Turtle>().GetPlankton();
            Destroy(this.gameObject);
        }

    }
}
