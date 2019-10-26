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

    GameObject Barrier, Sphere, RightPoint;

    public GameObject Projected;

    Color blueColor = new Color32(39, 79, 149, 1);

    public float checkFront;
    Vector3 ballAndBarrier;
    float ballAndBarrierDistance;

    Vector3 R, Opposite, ballAndShadow;
    float checkBehindMovingAway;
    public float checkFront2;
    Vector3 shadowAndBarrier;
    float shadowAndBarrierDistance;

    Vector3 iDir;

    void Start()
    {

        Barrier = GameObject.Find("TheBarrier");
        Sphere = GameObject.Find("TheSphere");
        RightPoint = GameObject.Find("RightLineEndPt");
        GetComponent<Renderer>().material.color = blueColor;

        Projected = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        
        Projected.GetComponent<Renderer>().material.color = Color.black;
        Projected.transform.localScale = new Vector3(Projected.transform.localScale.x, Projected.transform.localScale.y, (Sphere.transform.localScale.z) / 10);
        Projected.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        Projected.SetActive(false);


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


        shadowAndBarrier = Projected.transform.localPosition - center;
        shadowAndBarrierDistance = shadowAndBarrier.magnitude;
        //shadowAndBarrier.Normalize();

        ballAndBarrier = transform.localPosition - center;
        ballAndBarrierDistance = ballAndBarrier.magnitude;
        ballAndBarrier.Normalize();



        Projected.transform.localPosition = transform.localPosition - (n * h);
        Projected.transform.localPosition = Projected.transform.localPosition + 0.1f * n;
        Projected.SetActive(true);

        Debug.DrawLine(Projected.transform.localPosition, transform.localPosition, Color.black);
        n.Normalize();
        checkFront = Vector3.Dot(ballAndBarrier, n);
        checkFront2 = Vector3.Dot(ballAndBarrier, n);

        timeAlive += Time.deltaTime;
        if (timeAlive > aliveSec)
        {
            Destroy(Projected.transform.gameObject);
            Destroy(transform.gameObject);
            
        }

        float radius = (Sphere.transform.localScale.y)/ 2;

        Projected.SetActive(true);
        if (shadowAndBarrierDistance > radius)
        {
            Projected.SetActive(false);
            //Projected.GetComponent<Renderer>().enabled = false;
        }

        if (checkFront < 0)
        {
            Projected.SetActive(false);
            //Projected.GetComponent<Renderer>().enabled = false;
        }


        if (Vector3.Dot(dir, n) < 0 && checkFront <= 0)
        {
            R = dir - (2 * Vector3.Dot(dir, n)) * n;
            dir = R;
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

}
