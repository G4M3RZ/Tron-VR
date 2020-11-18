using UnityEngine;

public class DestroyParticles : MonoBehaviour {

    private void Awake()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        float time = ps.main.startLifetime.constant;
        Destroy(this.gameObject, time);
    }
}