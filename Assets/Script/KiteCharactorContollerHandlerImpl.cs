using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class KiteCharactorContollerHandlerImpl {

    public enum MoveDirection
    {
        Forward,
        Back,
        Left,
        Right,
    }

    public KiteCharactorInfo CharactorInfo { get; set; }

    public void GoToForward()
    {
        _currentFrameNeedMoveCache.Add(MoveDirection.Forward);
    }

    public void GoToBack()
    {
        _currentFrameNeedMoveCache.Add(MoveDirection.Back);
    }

    public void GoToLeft()
    {
        _currentFrameNeedMoveCache.Add(MoveDirection.Left);
    }

    public void GoToRight()
    {
        _currentFrameNeedMoveCache.Add(MoveDirection.Right);
    }

    public void Update()
    {
        var needUpdate = _currentFrameNeedMoveCache.Count != 0;
        if (needUpdate)
        {
            foreach (var direction in _currentFrameNeedMoveCache)
            {
                var needMoveVector = _moveDirectionVectorDic[direction];
                CharactorInfo.CharactorObj.transform.Translate(needMoveVector * MoveBaseValue);
            }
            _currentFrameNeedMoveCache.Clear();
        }
    }
}

public partial class KiteCharactorContollerHandlerImpl
{

    protected HashSet<MoveDirection> _currentFrameNeedMoveCache = new HashSet<MoveDirection>();
    protected Dictionary<MoveDirection, Vector3> _moveDirectionVectorDic = new Dictionary<MoveDirection, Vector3>()
    {
        { MoveDirection.Forward, Vector3.forward },
        { MoveDirection.Back, -Vector3.forward },
        { MoveDirection.Left, -Vector3.right },
        { MoveDirection.Right, Vector3.right },
    };

    protected float MoveBaseValue
    {
        get
        {
            return Time.deltaTime * CharactorInfo.WalkSpeed;
        }
    }

    private Rigidbody _charactorRigidBody;

    public Rigidbody CharactorRigidBody
    {
        get
        {
            if(_charactorRigidBody == null)
            {
                var charactorObj = CharactorInfo.CharactorObj;
                if(charactorObj)
                {
                    _charactorRigidBody = charactorObj.GetComponent<Rigidbody>();
                }
            }

            return _charactorRigidBody;
        }
    }
}