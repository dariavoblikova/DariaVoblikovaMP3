using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingBall : MonoBehaviour
{
    float t = 120;
    float D = 0;
    Vector3 velocity = Vector3.zero;
    public GameObject LeftLineEndPoint, RightLineEndPoint;

    public SliderWithEcho mTimeSlider;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;

        mTimeSlider.InitSliderRange(1, 600, 120);
        mTimeSlider.SetSliderLabel("Time");
        mTimeSlider.SetSliderListener(SetNewTime);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForReset();
        ComputeVelocity();

        // regular update
        transform.localPosition += (D / t) * velocity;
    }
    private void ComputeVelocity()
    {
        velocity = RightLineEndPoint.transform.localPosition - LeftLineEndPoint.transform.localPosition;
        D = velocity.magnitude;
        velocity.Normalize();
    }

    private void CheckForReset()
    {
        // check to see if we should reset position
        Vector3 v = transform.localPosition - LeftLineEndPoint.transform.localPosition;

        if (v.magnitude > D)
            transform.localPosition = LeftLineEndPoint.transform.localPosition;
    }

    private void SetNewTime(float nt)
    {
        t = nt;
    }
}
