using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KiteCharactorContollerHandlerImpl {

    public KiteCharactorInfo CharactorInfo { get; set; }

    public void GoToForward()
    {
        CharactorInfo.CharactorObj.transform.Translate(Vector3.forward * MoveBaseValue);
    }

    public void GoToBack()
    {
        CharactorInfo.CharactorObj.transform.Translate(-Vector3.forward * MoveBaseValue);
    }

    public void GoToLeft()
    {
        CharactorInfo.CharactorObj.transform.Translate(-Vector3.right * MoveBaseValue);
    }

    public void GoToRight()
    {
        CharactorInfo.CharactorObj.transform.Translate(Vector3.right * MoveBaseValue);
    }

}

public partial class KiteCharactorContollerHandlerImpl
{
    protected float MoveBaseValue
    {
        get
        {
            return Time.deltaTime * CharactorInfo.WalkSpeed;
        }
    }

}