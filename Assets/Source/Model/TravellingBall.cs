using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingBall : MonoBehaviour
{
    float D = 0;
    //Vector3 velocity = Vector3.zero;
    public GameObject LeftLineEndPoint, RightLineEndPoint;

    float mSpeed = 15;
    float mInterval = 1;
    float mAliveSec = 10;
    float mTimeAlive;
    Vector3 mDir = Vector3.zero;
    
    Color blueColor = new Color32(39,79,149,1);
    

    public SliderWithEcho mSpeedSlider;
    public SliderWithEcho mIntervalSlider;
    public SliderWithEcho mLifeSpanSlider;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Renderer>().material.color = Color.blue;
        GetComponent<Renderer>().material.color = blueColor;
     
        mSpeedSlider.InitSliderRange(0.5f, 15, 15);
        mSpeedSlider.SetSliderLabel("Speed");
        mSpeedSlider.SetSliderListener(SetNewSpeed);

        mIntervalSlider.InitSliderRange(0.5f, 4, 1);
        mIntervalSlider.SetSliderLabel("Interval");
        mIntervalSlider.SetSliderListener(SetNewInterval);

        mLifeSpanSlider.InitSliderRange(1, 15, 10);
        mLifeSpanSlider.SetSliderLabel("Alive Sec");
        mLifeSpanSlider.SetSliderListener(SetNewAliveSec);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForReset();
        ComputeVelocity();
        
        transform.localPosition += mDir * mSpeed * Time.deltaTime;

        mTimeAlive += Time.deltaTime;
        if (mTimeAlive > mAliveSec)
            Destroy(transform.gameObject);

    }
    private void ComputeVelocity()
    {
        mDir = RightLineEndPoint.transform.localPosition - LeftLineEndPoint.transform.localPosition;
        D = mDir.magnitude;
        mDir.Normalize();
    }

    private void CheckForReset()
    {
        // check to see if we should reset position
        Vector3 v = transform.localPosition - LeftLineEndPoint.transform.localPosition;

        if (v.magnitude > D)
            transform.localPosition = LeftLineEndPoint.transform.localPosition;
    }

    private void SetNewSpeed(float ns)
    {
        mSpeed = ns;
    }

    private void SetNewInterval(float ni)
    {
        mInterval = ni;
    }

    private void SetNewAliveSec(float na)
    {
        mAliveSec = na;
    }
}
