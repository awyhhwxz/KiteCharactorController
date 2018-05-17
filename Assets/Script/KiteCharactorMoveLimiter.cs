﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteCharactorMoveLimiter {

    public KiteCharactorContollerHandlerImpl CharactorContollerHandlerImpl;

    public bool IsAllowMove(Vector3 moveVector)
    {
        var charactorObj = CharactorContollerHandlerImpl.CharactorInfo.CharactorObj;
        var footPos = charactorObj.transform.position + charactorObj.transform.up * -GetFootY();
        var rayDirection = charactorObj.transform.TransformDirection(moveVector);
        if (Physics.Raycast(footPos, rayDirection, CharactorContollerHandlerImpl.Capsule.radius + moveVector.magnitude))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected float GetFootY()
    {
        var halfHeight = CharactorContollerHandlerImpl.Capsule.height * 0.5f;
        return halfHeight - CharactorContollerHandlerImpl.Capsule.radius;
    }
}
