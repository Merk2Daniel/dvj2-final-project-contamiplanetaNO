using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Movement")] //AGREGADO

    // Move object using accelerometer
    private float speed = 10.0f;
    public bool moveIsActivated; //AGREGADO //Para deshabilitar el movimiento cuando el temporizador (si lo ponemos) llegue a 0 o en alguna otra situación especial

    [Header ("Animator")] //AGREGADO
    public Animator anim; //AGREGADO
    private SpriteRenderer theSR; //AGREGADO

    void Start() //AGREGADO
    {
        anim = GetComponent<Animator>(); //AGREGADO
        theSR = GetComponent<SpriteRenderer>(); //AGREGADO
    }

    void Update()
    {
        Vector3 dir = Vector3.zero;

        dir.x =  /*Input.acceleration.x*/Input.GetAxis("Horizontal");
        dir.y = Input.acceleration.y;
        dir.z = Input.acceleration.z;

        if (dir.x < 0.2 && dir.x > - 0.2)
        {
            anim.SetBool("walking", false);
            dir.x = 0;
        }

        if (dir.x < - 0.2)
        {
            transform.localScale = new Vector3(-1,1,1);
            anim.SetBool ("walking",true);
        }

        if (dir.x > 0.2)
        {
            transform.localScale = new Vector3(1,1,1);
            anim.SetBool("walking", true);
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
