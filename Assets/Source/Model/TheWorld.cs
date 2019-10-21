using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class TheWorld : MonoBehaviour
{
    private GameObject mSelected = null;
    //LeftLineEndPt mSelected = null;
    public GameObject LeftPlane, RightPlane = null;
    public GameObject LeftLineEndPoint, RightLineEndPoint = null;
    Vector3 Vn, VnRight;
    public GameObject LineSegment = null;

    private Color kSelectedColor = new Color(0.8f, 0.8f, 0.1f, 0.5f);
    private Color mOrgObjColor = Color.white; // remember obj's original color
    Vector3 mDir;
    float lineSegmentLength;

    Vector3 delta;
    float distance;


    float D;

    void Start()
    {
        //LeftLineEndPoint.transform.localPosition = LeftPlane.transform.localPosition;
        LeftLineEndPoint.transform.localPosition = new Vector3(LeftPlane.transform.localPosition.x, 5, 16);
        RightLineEndPoint.transform.localPosition = new Vector3(RightPlane.transform.localPosition.x, 3, 9);


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

        Debug.DrawLine(LeftLineEndPoint.transform.localPosition, RightLineEndPoint.transform.localPosition, Color.black);
        
    }

    public GameObject SelectObject(GameObject obj)
    {
        if ((obj != null) && (obj.name == "CreationPlane"))
        {
            obj = null;
        }

        SetObjectSelection(obj);
        return mSelected;
    }

    public void MoveObject(GameObject obj, Vector3 pos)
    {
        //UnSelectCurrent();
        Debug.Log("object name: " + obj.name);
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

    private void SetObjectLocation(Vector3 pos)
    {
        Vector3 delta = mSelected.transform.position - pos;
        //delta.y = 0f; // let's not allow vertical component
        distance = delta.magnitude;
        if (distance < 0.001f)
            return;
        delta.Normalize();

    }

    private void SetObjectSelection(GameObject g)
    {
        if (mSelected != null)
            mSelected.GetComponent<Renderer>().material.color = mOrgObjColor;

        mSelected = g;
        if (mSelected != null)
        {
            mOrgObjColor = g.GetComponent<Renderer>().material.color; // save a copy
            mSelected.GetComponent<Renderer>().material.color = kSelectedColor;
        }
    }

    private void UnSelectCurrent()
    {
        if (mSelected != null)
        {
            mSelected = null;
        }
    }
}
