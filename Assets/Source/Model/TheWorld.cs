using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class TheWorld : MonoBehaviour
{
    public GameObject LeftPlane, RightPlane = null;
    public GameObject LeftLineEndPoint, RightLineEndPoint = null;
    Vector3 Vn, VnRight, VnBarrier, VnNormalBarrier;
    public GameObject LineSegment = null;

    private Color kSelectedColor = new Color(0.8f, 0.8f, 0.1f, 0.5f);
    private Color mOrgObjColor = Color.white; // remember obj's original color
    public Vector3 mDir;
    float lineSegmentLength;

    Vector3 delta;
    float distance;


    float D;

    public GameObject mTheBarrier;
    public GameObject MySphere;
    public GameObject MyNormal = null;

    private GameObject mSelected = null;



    public Vector3 n;
    public Vector3 center;
    float d;

    void Start()
    {
        LeftLineEndPoint.transform.localPosition = new Vector3(LeftPlane.transform.localPosition.x, 5, 16);
        RightLineEndPoint.transform.localPosition = new Vector3(RightPlane.transform.localPosition.x, 3, 9);

        mTheBarrier.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        MySphere.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        RightLineEndPoint.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        LeftLineEndPoint.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        MyNormal.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;



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

    private void Update()
    {

        Vn = -LeftPlane.transform.forward;
        //LeftLineEndPoint.transform.localPosition = LeftPlane.transform.localPosition + 0.1f * Vn;

        VnRight = -RightPlane.transform.forward;

        LeftLineEndPoint.transform.up = Vn;
        RightLineEndPoint.transform.up = VnRight;
        //LineSegment.transform.up = LeftLineEndPoint.transform.up;


        mDir = RightLineEndPoint.transform.localPosition - LeftLineEndPoint.transform.localPosition;
        lineSegmentLength = mDir.magnitude;
        mDir.Normalize();

        LineSegment.transform.localRotation = Quaternion.FromToRotation(Vector3.up, mDir);
        LineSegment.transform.localScale = new Vector3(0.1f, lineSegmentLength / 2, 0.1f);
        LineSegment.transform.localPosition = LeftLineEndPoint.transform.localPosition + lineSegmentLength * 0.5f * mDir;

        //Debug.DrawLine(LeftLineEndPoint.transform.localPosition, RightLineEndPoint.transform.localPosition, Color.black);


        //MySphere.transform.localScale = new Vector3(mTheBarrier.transform.localScale.x, mTheBarrier.transform.localScale.y, 0.1f);
        MySphere.transform.localScale = new Vector3(mTheBarrier.transform.localScale.x, mTheBarrier.transform.localScale.y, (mTheBarrier.transform.localScale.z)/10);//instead of above to check scale
        VnBarrier = mTheBarrier.transform.up;
        MySphere.transform.localPosition = mTheBarrier.transform.localPosition + 0.05f * VnBarrier;
        MySphere.transform.localRotation = mTheBarrier.transform.localRotation;


        

        VnNormalBarrier = -mTheBarrier.transform.forward;
        //VnNormalBarrier.Normalize();//new
        MyNormal.transform.localRotation = Quaternion.FromToRotation(Vector3.up, VnNormalBarrier);
        MyNormal.transform.localScale = new Vector3(0.1f, 2.5f, 0.1f);
        MyNormal.transform.localPosition = mTheBarrier.transform.localPosition + 5 * 0.5f * VnNormalBarrier;




        mTimeSinceLastBall += Time.deltaTime;
        //Debug.Log("time since last ball" + mTimeSinceLastBall);
        if (mTimeSinceLastBall > mInterval)
        {
            CreateBall(LeftLineEndPoint.transform.localPosition);
            mTimeSinceLastBall = 0;
        }


    }

    public void MoveObject(GameObject obj, Vector3 pos)
    {
        //Debug.Log("object name: " + obj.name);
        if (obj.name == "LeftWall") {
            //pos.x = 0f;
            if (pos.y >= 0 && pos.y <= 17 && pos.z >= 0 && pos.z <= 24)
            {
                LeftLineEndPoint.transform.localPosition = pos;
            }
            
        }
        if (obj.name == "RightWall")
        {
            //pos.x = 0f;
            if (pos.y >= 0 && pos.y <= 17 && pos.z >= 0 && pos.z <= 24)
            {
                RightLineEndPoint.transform.localPosition = pos;
            }

        }


    }



    public GameObject SelectObject(GameObject obj)
    {
        if ((obj != null) && (obj.name == "TheBarrier"))
        {
            SetObjectSelection(obj);
        }
        return mSelected;

    }

    private void SetObjectSelection(GameObject g)
    {
        mSelected = g;
    }


}
