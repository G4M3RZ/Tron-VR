using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpawnPosition : MonoBehaviour
{
    public bool _editMode;
    [Range(0, 100)] public float _distance; 
    [Range(0, 10)] public float _up, _separation;
    private List<Transform> spawners;

    private void Awake()
    {
        _editMode = false;
        spawners = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
            spawners.Add(transform.GetChild(i));
    }

    private void Update()
    {
        if (_editMode)
        {
            for (int i = -1; i <= 1; i++)
            { 
                spawners[i + 1].position = new Vector3(i * _separation, _up, _distance);
                spawners[i + 1].localEulerAngles = new Vector3(0, 180, 0); 
            }
        }
    }
}