using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;

    private float target_posX; //Posici�n X del jugador

    private float posX; //Posici�n X de la c�mara
    //private float posY; //Posici�n Y de la c�mara

    public float right_side; //L�mite lado derecho
    public float left_side; //L�mite lado izquierdo

    public float speed; //Velocidad
    public bool active = true; //C�mara encendida

    private void Awake()
    {
        posX = target_posX + right_side;
        //posY = target_posY + max_height;
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, 0, -1), 1);
    }

    void MoveCam()
    {
        if (active)
        {
            if (target)
            {
                target_posX = target.transform.position.x;
                if (target_posX > right_side && target_posX < left_side)
                {
                    posX = target_posX;
                }
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, 0, -1), speed * Time.deltaTime);
        }
    }

    void Update()
    {
        MoveCam();
    }
}
