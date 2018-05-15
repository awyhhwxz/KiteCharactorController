using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteCharactorContollerHandler
{

    public bool IsEnable { get; set; }

    private KiteCharactorContollerHandlerImpl _charactorHandlerImpl = new KiteCharactorContollerHandlerImpl();
    private KiteCharactorCameraHandler _cameraHandler = new KiteCharactorCameraHandler();

    public KiteCharactorInfo CharactorInfo = new KiteCharactorInfo();

    public KiteCharactorContollerHandler()
    {
        IsEnable = true;
        CharactorInfo.WalkSpeed = 1f;
        _charactorHandlerImpl.CharactorInfo = CharactorInfo;
        _cameraHandler.CharactorInfo = CharactorInfo;
    }

    protected bool IsCharactorStateChangable { get { return IsEnable && CharactorInfo.CharactorObj; } }

    public void GoToForward()
    {
        if (IsCharactorStateChangable) _charactorHandlerImpl.GoToForward();
    }

    public void GoToBack()
    {
        if (IsCharactorStateChangable) _charactorHandlerImpl.GoToBack();
    }

    public void GoToLeft()
    {
        if (IsCharactorStateChangable) _charactorHandlerImpl.GoToLeft();
    }

    public void GoToRight()
    {
        if (IsCharactorStateChangable) _charactorHandlerImpl.GoToRight();
    }

    public void SetHorizontalOffset(float offset)
    {
        if (IsCharactorStateChangable) _cameraHandler.SetHorizontalOffset(offset);
    }

    public void SetVerticalOffset(float offset)
    {
        if (IsCharactorStateChangable) _cameraHandler.SetVerticalOffset(offset);
    }
}
