using UnityEngine;

public class Movement : MonoBehaviour {

    [Range(0, 5)] public float _limits, _speed;
    private CamRotation _cam;
    private Transform _graphic;
    private Shield _sh;

    private void Awake()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamRotation>();
        _sh = GetComponent<Shield>();
        _graphic = transform.GetChild(0);
    }
    private void Update()
    {
        if (!_sh._death)
        {
            //movement
            Vector3 pos = transform.localPosition;
            float velocity = _speed * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x - (_cam._rotZ * velocity), -_limits, _limits);
            transform.localPosition = pos;

            //rotation
            _graphic.Rotate(5, 0, 0);
        }
    }
}