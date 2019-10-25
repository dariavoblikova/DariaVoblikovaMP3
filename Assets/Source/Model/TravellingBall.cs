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


    public Vector3 n;
    public float myd;
    public Vector3 center;

    GameObject Barrier;

    public GameObject Projected;

    Color blueColor = new Color32(39, 79, 149, 1);

    public float checkFront;

    void Start()
    {

        Barrier = GameObject.Find("TheBarrier");
        GetComponent<Renderer>().material.color = blueColor;

        Projected = GameObject.CreatePrimitive(PrimitiveType.Sphere);//new line
        Projected.transform.localScale = new Vector3(Projected.transform.localScale.x, Projected.transform.localScale.y, (Barrier.transform.localScale.z) / 10);
        Projected.GetComponent<Renderer>().material.color = Color.black;//new line
        //Projected.transform.localPosition = new Vector3(transform.localPosition.x + 2, transform.localPosition.y + 2, transform.localPosition.z + 2);

        Projected.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;


    }

    void Update()
    {
        transform.localPosition += dir * speed * Time.deltaTime;




        // the plane and its normal
        n = -Barrier.transform.forward;
        center = Barrier.transform.localPosition;
        //Vector3 pt = center + kNormalSize * n;
        Projected.transform.localRotation = Quaternion.FromToRotation(Vector3.forward, n);
        myd = Vector3.Dot(n, center);
        float h = Vector3.Dot(transform.localPosition, n) - myd;


        Vector3 ballAndBarrier = Projected.transform.localPosition - Barrier.transform.localPosition;
        //float ballAndBarrierDistance = ballAndBarrier.magnitude;
        //ballAndBarrier.Normalize();



        Projected.transform.localPosition = transform.localPosition - (n * h);
        Projected.transform.localPosition = Projected.transform.localPosition + 0.1f * n;

        Debug.DrawLine(Projected.transform.localPosition, transform.localPosition, Color.black);
        checkFront = Vector3.Dot(ballAndBarrier, n);

        timeAlive += Time.deltaTime;
        if (timeAlive > aliveSec)
            Destroy(transform.gameObject);


        //if ((Mathf.Abs(Projected.transform.localPosition.x - center.x) > 6 || Mathf.Abs(Projected.transform.localPosition.y - center.y) > 6) && (checkFront < 0))
        //{
        //    //Projected.SetActive(false);
        //    Projected.GetComponent<Renderer>().enabled = false;
        //}

        if ( checkFront < 0)
        {
            Projected.SetActive(false);
            //Projected.GetComponent<Renderer>().enabled = false;
        }


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



    //// the plane and its normal
    //Vector3 n = -ThePlane.transform.forward;
    //Vector3 center = ThePlane.transform.localPosition;
    //Vector3 pt = center + kNormalSize * n;
    //float d = Vector3.Dot(n, center);

    //float h = Vector3.Dot(ThePoint.transform.localPosition, n) - d;
    //Projected.transform.localPosition = ThePoint.transform.localPosition - (n* h);
    //    float s = h * 0.50f;
    //    if (s< 0)
    //        s = 0.5f;
    //    Projected.transform.localScale = new Vector3(s, s, s);
    //Debug.DrawLine(Projected.transform.localPosition, ThePoint.transform.localPosition, Color.black);

    //    // normal
    //    float size = h / 2;
    //Vector3 scale = PlaneNormal.transform.localScale;
    //scale.y = size;
    //    PlaneNormal.transform.localScale = scale;
    //    PlaneNormal.transform.localRotation = Quaternion.FromToRotation(Vector3.up, n);
    //    PlaneNormal.transform.localPosition = Projected.transform.localPosition + (size* PlaneNormal.transform.up);


    //    Debug.DrawLine(center, pt, Color.black);
    //    // for debugging: Debug.Log(hit + ":" + details);
}
