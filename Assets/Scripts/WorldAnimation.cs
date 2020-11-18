using UnityEngine;

public class WorldAnimation : MonoBehaviour {

    [Range(-100, 100)]
    public float _backAnim;
    float startPosZ, endPosZ;

    private void Awake()
    {
        startPosZ = transform.localPosition.z;
        endPosZ = startPosZ + (_backAnim * 2);

        Vector3 pos = transform.localPosition;
        transform.localPosition = new Vector3(pos.x, pos.y, endPosZ);
    }
    private void Update()
    {
        Vector3 currentPos = transform.localPosition;
        currentPos.z = Mathf.Lerp(currentPos.z, startPosZ, Time.deltaTime * 2);
        transform.localPosition = currentPos;
    }
}