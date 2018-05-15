using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteCharactorInfo {

    public float WalkSpeed { get; set; }
    public GameObject CharactorObj { get; set; }

    public float CameraHorizontalSpeed = 10.0f;
    public float CameraVerticalSpeed = 10.0f;

    public float CameraMaxVerticalAngle = 60.0f;
    public float CameraMinVerticalAngle = 60.0f;
}
