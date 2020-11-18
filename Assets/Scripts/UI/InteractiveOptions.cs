using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveOptions : MonoBehaviour {

    private InteractiveMenu _menu;
    private GvrReticlePointer _rp;

    private int _qSelection;
    private List<Toggle> _qualityMarks;

    private void Awake()
    {
        _menu = GetComponent<InteractiveMenu>();
        Transform cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _rp = cam.GetChild(0).GetComponent<GvrReticlePointer>();
        
        _qualityMarks = new List<Toggle>();
        int quality = QualitySettings.GetQualityLevel();

        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            _qualityMarks.Add(transform.GetChild(0).GetChild(i).GetComponent<Toggle>());
            _qualityMarks[i].isOn = (i == quality) ? true : false;
        }
    }
    private void Update()
    {
        #region Quality Setting
        if (_rp.ReticleOuterDiameter >= 0.03f && _qSelection != 0)
        {
            QualitySettings.SetQualityLevel(_qSelection - 1);

            for (int i = 0; i < _qualityMarks.Count; i++)
            {
                bool active = (_qSelection - 1 == i) ? true : false;
                _qualityMarks[i].isOn = active;
            }

            _qSelection = 0;
        }
        #endregion

        #region Sound Setting
        if (_rp.ReticleOuterDiameter >= 0.03f)
        {

        }
        #endregion
    }
    public void SelectQuality(int value)
    {
        _qSelection = value;
        _rp.reticleGrowthSpeed = _menu._selectSpeed;
    }
    public void DeselectQuality()
    {
        _qSelection = 0;
        _rp.reticleGrowthSpeed = _menu._deSelectSpeed;
    }
}