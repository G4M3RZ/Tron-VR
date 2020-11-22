using UnityEngine;

public class Obstaculos : MonoBehaviour {

    private SpawnerController _sc;
    private Rigidbody _rb;

    float parentPos;

    private void Awake()
    {
        _sc = GetComponentInParent<SpawnerController>();
        _rb = GetComponent<Rigidbody>();

        parentPos = transform.parent.localPosition.z;
    }
    void FixedUpdate()
    {
        _rb.velocity = transform.forward * _sc._currentSpeed;

        if (transform.localPosition.z > _sc.backLimit + parentPos)
            Destroy(this.gameObject);
    }
}