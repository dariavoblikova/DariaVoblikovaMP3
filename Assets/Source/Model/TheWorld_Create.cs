﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TheWorld : MonoBehaviour
{
    //Vector3 velocity = Vector3.zero;

    public float mSpeed = 15;
    float mInterval = 1;
    public float mAliveSec = 10;
    float mTimeAlive;
    float mTimeSinceLastBall = 1; // initial value equals mInterval, then resets

    Color blueColor = new Color32(39, 79, 149, 1);


    public SliderWithEcho mSpeedSlider;
    public SliderWithEcho mIntervalSlider;
    public SliderWithEcho mLifeSpanSlider;


    TravellingBall mSelectedSphere = null;


    public void CreateBall(Vector3 pos)
    {
        //GameObject g = Instantiate(Resources.Load("TravellingBallPrefab")) as GameObject;
        
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        g.transform.localScale = new Vector3(1, 1, 1);
        g.transform.localPosition = pos;
        mSelectedSphere = g.AddComponent<TravellingBall>();
        
        Debug.Assert(mSelectedSphere != null);
        
        mSelectedSphere.ComputeSpeed(mSpeed);
        mSelectedSphere.ComputeVelocity(RightLineEndPoint.transform.localPosition, LeftLineEndPoint.transform.localPosition);
        mSelectedSphere.ComputeAliveSec(mAliveSec);

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