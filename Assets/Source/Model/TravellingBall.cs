using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingBall : MonoBehaviour
{
    float timeAlive;
    public float speed;
    public Vector3 dir;
    float d;
    public float aliveSec;


    Color blueColor = new Color32(39, 79, 149, 1);

    void Start()
    {
        GetComponent<Renderer>().material.color = blueColor;

    }

    void Update()
    {
        transform.localPosition += dir * speed * Time.deltaTime;

        timeAlive += Time.deltaTime;
        if (timeAlive > aliveSec)
            Destroy(transform.gameObject);

    }
    public void ComputeVelocity(Vector3 right, Vector3 left)
    {
        dir = right - left;
        d = dir.magnitude;
        dir.Normalize();
    }

    public void ComputeSpeed(float speedL)
    {
        speed = speedL;

    }

    public void ComputeAliveSec(float aliveL)
    {
        aliveSec = aliveL;

    }


}
