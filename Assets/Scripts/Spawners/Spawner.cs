using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject _shield;
    public List<GameObject> _obs;
    public Vector3 _position, _rotation;
    public bool _backwards;

    public void Spawn()
    {
        int random = Random.Range(0, 5);

        if (_shield == null) SpawnObs();
        else if (random == 1) SpawnItem(); else SpawnObs();
    }
    void SpawnObs()
    {
        GameObject obs = Instantiate(_obs[Random.Range(0, _obs.Count)], transform);
        obs.transform.localPosition = _position;
        obs.transform.localEulerAngles = _rotation;
    }
    void SpawnItem()
    {
        GameObject obs = Instantiate(_shield, transform);
        obs.transform.localPosition = new Vector3(0, 0.2f, 0);
        obs.transform.localEulerAngles = _rotation;
    }
}