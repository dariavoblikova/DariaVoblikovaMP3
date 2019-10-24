using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MainController : MonoBehaviour
{
    // reference to all UI elements in the Canvas
    public Camera MainCamera = null;
    public XfromControl mXform = null;
    public TheWorld mModel = null;
    public SliderWithEcho mSpeedSlider = null; //maybe not
    public SliderWithEcho mIntervalSlider = null;
    public SliderWithEcho mLifeSpanSlider = null;


    // Use this for initialization
    void Start()
    {
        Debug.Assert(MainCamera != null);
        Debug.Assert(mXform != null);
        Debug.Assert(mModel != null);
        Debug.Assert(mSpeedSlider != null);
        Debug.Assert(mIntervalSlider != null);
        Debug.Assert(mLifeSpanSlider != null);
    }

    // Update is called once per frame
    void Update()
    {
        LMBSelect();
        SelectObject(mModel.mTheBarrier);
    }

    private void SelectObject(GameObject g) //delete redundant because don't need to update xForm
    {
        GameObject a = mModel.SelectObject(g);
        mXform.SetSelectedObject(a);
    }

}
