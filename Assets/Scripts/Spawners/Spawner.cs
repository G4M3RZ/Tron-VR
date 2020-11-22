using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject _shield;
    public List<GameObject> _obs;
    [Range(0, 10)] public float _position;
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
        obs.transform.localPosition = new Vector3(0, _position, 0);
    }
    void SpawnItem()
    {
        GameObject obs = Instantiate(_shield, transform);
        obs.transform.localPosition = new Vector3(0, _position / 15, 0);
    }
}