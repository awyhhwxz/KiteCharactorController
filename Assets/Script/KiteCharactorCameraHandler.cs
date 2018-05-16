using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteCharactorCameraHandler {

    public KiteCharactorInfo CharactorInfo { get; set; }

    protected float _currentVerticalRotate = 0f;

    public void SetHorizontalOffset(float offset)
    {
        var charactorObj = CharactorInfo.CharactorObj;
        if(charactorObj)
        {
            charactorObj.transform.localRotation *= Quaternion.AngleAxis(offset * CharactorInfo.CameraHorizontalSpeed, Vector3.up);
        }
    }

    public void SetVerticalOffset(float offset)
    {
        var cameraObj = _CameraObj;
        if (cameraObj)
        {
            _currentVerticalRotate = Mathf.Clamp(_currentVerticalRotate - offset * CharactorInfo.CameraHorizontalSpeed, CharactorInfo.CameraMinVerticalAngle, CharactorInfo.CameraMaxVerticalAngle);
            cameraObj.transform.localEulerAngles = new Vector3(_currentVerticalRotate, 0, 0);
        }
    }

    private GameObject _cameraObj = null;
    protected GameObject _CameraObj {
        get
        {
            if(_cameraObj == null)
            {
                var charactorObj = CharactorInfo.CharactorObj;
                if(charactorObj)
                {
                    var eyeBase = charactorObj.transform.Find("EyeBase");
                    if(eyeBase)
                    {
                        _cameraObj = eyeBase.gameObject;
                    }
                }
            }

            return _cameraObj;
        }
    }
}
