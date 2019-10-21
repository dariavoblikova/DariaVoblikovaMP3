using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI; // for GUI elements: Button, Toggle
using UnityEngine.EventSystems;

public partial class MainController : MonoBehaviour
{
    void LMBSelect()
    {
        GameObject selectedObj;
        Vector3 hitPoint;
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
        {
            // Debug.Log("Mouse is down");

            if (MouseSelectObjectAt(out selectedObj, out hitPoint, LayerMask.GetMask("Default"))) // Notice the two ways of getting the mask
            {
                mModel.MoveObject(selectedObj, hitPoint);
            }
        }

    }

    bool MouseSelectObjectAt(out GameObject g, out Vector3 p, int layerMask)
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, layerMask);
        // Debug.Log("MouseSelect:" + layerMask + " Hit=" + hit);
        if (hit)
        {
            g = hitInfo.transform.gameObject;
            p = hitInfo.point;
        }
        else
        {
            g = null;
            p = Vector3.zero;
        }
        return hit;
    }
}
