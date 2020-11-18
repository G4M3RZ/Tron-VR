using System.Collections.Generic;
using UnityEngine;

public class DeadView : MonoBehaviour
{
    public List<GameObject> _views;

    private Map_Rotation _map;
    private Transform spawner;

    private void Awake()
    {
        _map = GetComponentInParent<Map_Rotation>();
        spawner = GameObject.FindGameObjectWithTag("Respawn").transform;
        DeathWindow(false);
    }
    public void DeathWindow(bool condition)
    {
        _map._rotate = !condition;

        for (int i = 0; i < _views.Count; i++)
            _views[i].SetActive(condition);

        if (condition)
        {
            List<GameObject> obs = new List<GameObject>();

            for (int i = 0; i < spawner.childCount; i++)
                for (int j = 0; j < spawner.GetChild(i).childCount; j++)
                    obs.Add(spawner.GetChild(i).GetChild(j).gameObject);

            foreach (GameObject Obstaculo in obs)
                Destroy(Obstaculo);
        }
    }
}