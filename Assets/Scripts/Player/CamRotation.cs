using UnityEngine;

public class CamRotation : MonoBehaviour {

    public float _rotZ;

	void Update () 
    {
        float camRot = transform.localEulerAngles.z;
        float rot = (camRot <= 180) ? camRot : camRot - 360;
        _rotZ = rot / 10;
    }
}