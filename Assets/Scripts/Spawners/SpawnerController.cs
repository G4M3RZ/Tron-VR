using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [HideInInspector] public float _currentSpeed, _spawnTime;
    [Range(0, 100)] public float _startSpeed, _maxSpeed;
    [Range(0, 5)] public float _sInitTime, _sLastTime;
    [Range(0, 20)] public float backLimit;
    public List<Scroll> _map;
    public GameObject _tutorial;
    
    private Shield _sh;
    private List<Transform> spawner;

    private void Awake()
    {
        _currentSpeed = _startSpeed;
        _spawnTime = _sInitTime;

        _sh = GameObject.FindGameObjectWithTag("Player").GetComponent<Shield>();

        spawner = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
            spawner.Add(transform.GetChild(i));

        Scroll(_startSpeed / _maxSpeed);
        StartCoroutine(SpawnProgression());
    }
    private void Update()
    {
        if (!_sh._death)
        {
            _currentSpeed = Mathf.Clamp(_currentSpeed += Time.deltaTime, _startSpeed, _maxSpeed);
            _spawnTime = Mathf.Clamp(_spawnTime -= Time.deltaTime / 30, _sLastTime, _sInitTime);

            float velocity = Time.deltaTime / (_maxSpeed * 10);
            float scroll = Mathf.Clamp(_map[0].scrolly += velocity, _startSpeed / _maxSpeed, _maxSpeed / 150);
            Scroll(scroll);
        }
    }
    void Scroll(float value)
    {
        int j = 1;

        for (int i = 0; i < _map.Count; i += 2)
        {
            _map[i].scrolly = value * j;
            j = -j;
        }
    }
    IEnumerator SpawnProgression()
    {
        yield return new WaitUntil(() => _tutorial == null);

        while (!_sh._death)
        {
            int select = Random.Range(0, 3);
            spawner[select].GetComponent<Spawner>().Spawn();

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}