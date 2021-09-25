using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{   private float speed;
    private Vector3 currentTarget;
    public Transform pointA;
    public Transform pointB;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var step = speed * Time.deltaTime;
        if (transform.position == pointA.position) {
            currentTarget = pointB.position;
        } else if (transform.position == pointB.position) {
            currentTarget = pointA.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, step); 
    }

}
