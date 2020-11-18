using UnityEngine;

public class Obstaculos : MonoBehaviour {

    private SpawnerController _sc;
    private Spawner _sp;
    private Rigidbody _rb;

    int direction;
    float parentPos;

    private void Awake()
    {
        _sc = GetComponentInParent<SpawnerController>();
        _sp = GetComponentInParent<Spawner>();
        _rb = GetComponent<Rigidbody>();

        direction = (!_sp._backwards) ? 1 : -1;
        parentPos = transform.parent.localPosition.z;
    }
    void FixedUpdate()
    {
        _rb.velocity = transform.forward * _sc._currentSpeed * direction;

        if (transform.localPosition.z + parentPos < -_sc.backLimit)
            Destroy(this.gameObject);
    }
}