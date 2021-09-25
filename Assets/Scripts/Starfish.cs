using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfish : MonoBehaviour
{
// Start is called before the first frame update
// Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<Turtle>().GetStarfish();
            Destroy(this.gameObject);
        }

    }
}
