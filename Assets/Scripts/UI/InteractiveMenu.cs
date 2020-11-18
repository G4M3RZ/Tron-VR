using UnityEngine;

public class InteractiveMenu : MonoBehaviour {

    [Range(0, 10)]
    public float _selectSpeed, _deSelectSpeed;
    public GameObject _fade;

    private Transform _cam;
    private GvrReticlePointer _rp;

    private string _newScene;
    private bool _selected;

    private void Awake()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _rp = _cam.GetChild(0).GetComponent<GvrReticlePointer>();
    }
    private void Update()
    {
        if (_rp.ReticleOuterDiameter >= 0.03f && _newScene != null && !_selected) 
        {
            GameObject fade = Instantiate(_fade, _cam);
            fade.GetComponent<FadeController>()._sceneName = _newScene;
            _selected = true;
        }
    }

    public void SelectButton(string sceneName)
    {
        _newScene = sceneName;
        _rp.reticleGrowthSpeed = _selectSpeed;
    }
    public void DeselectButton()
    {
        _newScene = null;
        _rp.reticleGrowthSpeed = _deSelectSpeed;
    }
}