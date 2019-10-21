using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainController : MonoBehaviour
{
    // reference to all UI elements in the Canvas
    public Camera MainCamera = null;
    public XfromControl mXform = null;
    public TheWorld mModel = null;
    public SliderWithEcho mTimeSlider = null; //maybe not


    // Use this for initialization
    void Start()
    {
        Debug.Assert(MainCamera != null);
        Debug.Assert(mXform != null);
        Debug.Assert(mModel != null);
        Debug.Assert(mTimeSlider != null);
    }

    // Update is called once per frame
    void Update()
    {
        LMBSelect();
    }

    private void SelectObject(GameObject g) //delete redundant because don't need to update xForm
    {
        GameObject a = mModel.SelectObject(g);
        mXform.SetSelectedObject(a);
    }

}
