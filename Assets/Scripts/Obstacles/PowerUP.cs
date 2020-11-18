using UnityEngine;

public class PowerUP : MonoBehaviour {

    private SpawnerController _sc;
    private Rigidbody _rb;

    private void Awake()
    {
        _sc = GetComponentInParent<SpawnerController>();
        _rb = GetComponent<Rigidbody>();
    }
    void Update ()
    {
        _rb.velocity = transform.forward * _sc._currentSpeed;

        if (transform.localPosition.z < -_sc.backLimit)
            Destroy(this.gameObject);
    }
}