using UnityEngine;

public class Map_Rotation : MonoBehaviour {

    public bool _rotate;
    private Transform _cam;

    private void Awake()
    {
        _rotate = true;
        _cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    void Update ()
    {
        if (_rotate && _cam != null)
        {
            Vector3 rotation = transform.eulerAngles;
            rotation.y = _cam.eulerAngles.y;
            transform.eulerAngles = rotation;
        }
	}
}