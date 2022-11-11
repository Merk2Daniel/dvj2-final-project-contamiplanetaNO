using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Move object using accelerometer
    private float speed = 10.0f;

    void Update()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;
        dir.z = Input.acceleration.z;

        if (dir.x < 0.2 && dir.x > - 0.2)
        {
            GetComponent<Animator>().SetBool("walking", false);
            dir.x = 0;
        }

        if (dir.x < - 0.2)
        {
            if (!GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            GetComponent<Animator>().SetBool ("walking",true);
        }

        if (dir.x > 0.2)
        {
            if (GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            GetComponent<Animator>().SetBool("walking", true);
        }

        // clamp acceleration vector to unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        // Move object
        transform.Translate(new Vector3(dir.x * speed, 0,0));
    }
}
