using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteCharactorMoveLimiter {

    public KiteCharactorContollerHandlerImpl CharactorContollerHandlerImpl;

    public bool IsAllowMove(Vector3 moveVector, out float yOffset)
    {
        yOffset = 0.0f;
        var charactorObj = CharactorContollerHandlerImpl.CharactorInfo.CharactorObj;
        var footPos = charactorObj.transform.position + charactorObj.transform.up * -GetFootY();
        var rayDirection = charactorObj.transform.TransformDirection(moveVector);
        //the first raycast, check for front of role
        if (Physics.Raycast(footPos, rayDirection, CharactorContollerHandlerImpl.Capsule.radius + moveVector.magnitude))
        {
            return false;
        }
        else
        {
            var stepHeight = CharactorContollerHandlerImpl.CharactorInfo.StepHeight;
            var belowForward = -charactorObj.transform.up;
            var nextFrameFootPoint = footPos + rayDirection;
            var radius = CharactorContollerHandlerImpl.Capsule.radius;
            var rayMaxLength = radius + stepHeight;
            RaycastHit hitInfo;
            //the second raycast, check for slope 
            if (Physics.Raycast(nextFrameFootPoint, belowForward, out hitInfo, rayMaxLength))
            {
                var nextFrameDistance = hitInfo.distance;
                //if the impact point in the step scope
                if (hitInfo.distance > radius - stepHeight)
                {
                    //the third raycast, for calculate y offset
                    if (Physics.Raycast(footPos, belowForward, out hitInfo, rayMaxLength))
                    {
                        var currentFrameDistance = hitInfo.distance;
                        if (!Mathf.Equals(nextFrameDistance, currentFrameDistance))
                        {
                            yOffset = currentFrameDistance - nextFrameDistance;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
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
