using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLineEndPt : MonoBehaviour
{
    public GameObject leftEnd = null;
    public GameObject leftWall = null;

    static Vector3 sMin = new Vector3(-10f, -10f, -10f);
    static Vector3 sMax = new Vector3(10f, 10f, 10f);
    //public Vector3 mMovementDirection = Vector3.up; // the movement direction
    //public float mLinearSpeed = 1f;

    //private int mDirection = 1;                     // moving in positive or negative direction

    public float xRange = 17f;
    public float yRange = 17f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(leftWall != null);
        leftEnd.transform.SetParent(leftWall.transform);
    }

    // Update is called once per frame
    void Update()
    {
        // float dt = Time.deltaTime;
        leftEnd.transform.localPosition = leftWall.transform.localPosition;

        // Vector3 delta = mMovementDirection * (mDirection * mLinearSpeed * dt);
        // float test = Vector3.Dot(transform.localPosition, mMovementDirection);

        //while (Mathf.Abs(p.x) < xRange) { }
        //while (Mathf.Abs(p.y) < yRange) { }

        //transform.localPosition = transform.localPosition + mSpeed * mVelocityDir;
        //if ((transform.localPosition.x < sMin.x) || (transform.localPosition.x > sMax.x))
        //    mVelocityDir.x *= -1;
        //if ((transform.localPosition.y < sMin.y) || (transform.localPosition.y > sMax.y))
        //    mVelocityDir.y *= -1;
        //if ((transform.localPosition.z < sMin.z) || (transform.localPosition.z > sMax.z))
        //    mVelocityDir.z *= -1;

    }

    public void SetPosition(ref Vector3 pos)
    {
        Vector3 delta = transform.position - pos;
        delta.y = 0f; // let's not allow vertical component
        float size = delta.magnitude;
        if (size < 0.001f)
            return;

        transform.position = new Vector3(2 * size, 2 * size, 2 * size);
        // mVelocityDir = delta / size;
    }
}
