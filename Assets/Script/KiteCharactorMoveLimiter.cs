using System.Collections;
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

    public bool IsAllowJump()
    {
        var charactorObj = CharactorContollerHandlerImpl.CharactorInfo.CharactorObj;
        var footPos = charactorObj.transform.position + charactorObj.transform.up * -GetFootY();
        Debug.DrawLine(footPos, footPos - charactorObj.transform.up * CharactorContollerHandlerImpl.Capsule.radius * 1.1f);

        var objs = Physics.OverlapSphere(footPos, CharactorContollerHandlerImpl.Capsule.radius * 1.1f);
        bool isAllow = false; 
        foreach (var obj in objs)
        {
            if(obj != charactorObj)
            {
                isAllow = true;
            }
        }
        return isAllow;
    }

    protected Vector3 GetFootPos()
    {
        var charactorObj = CharactorContollerHandlerImpl.CharactorInfo.CharactorObj;
        return charactorObj.transform.position + charactorObj.transform.up * -GetFootY();
    }

    protected float GetFootY()
    {
        var halfHeight = CharactorContollerHandlerImpl.Capsule.height * 0.5f;
        return halfHeight - CharactorContollerHandlerImpl.Capsule.radius;
    }
}
