using UnityEngine;

public class Shield : MonoBehaviour
{
    [HideInInspector] public bool _shield, _death;
    public GameObject _particles;
    private ParticleSystem _ps;
    private DeadView _dC;

    private void Awake()
    {
        _ps = transform.GetChild(1).GetComponent<ParticleSystem>();
        _dC = GameObject.FindGameObjectWithTag("GameController").GetComponent<DeadView>();
    }
    public void ShieldActivator(bool active, GameObject collision)
    {
        Instantiate(_particles, transform.position, transform.rotation);
        if (active) _ps.Play(); else _ps.Stop();
        Destroy(collision);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Power Up"))
        {
            ShieldActivator(true, collision.gameObject);
            _shield = true;
        }

        if (collision.collider.CompareTag("Enemy") && _shield)
        {
            ShieldActivator(false, collision.gameObject);
            _shield = false;
        }
        else if (collision.collider.CompareTag("Enemy") && !_shield)
        {
            ShieldActivator(false, null);
            _dC.DeathWindow(true);
            _death = true;
            this.gameObject.SetActive(false);
        }
    }
}