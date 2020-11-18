using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    [Range(0, 1)] public float _speed;
    private Color _fade;
    private Image _mat;

    void Awake ()
    {
        _fade = Color.white;
        _mat = GetComponent<Image>();
    }
	void Update ()
    {
        _mat.color = _fade;
        _fade.a = Mathf.Clamp(_fade.a -= Time.deltaTime * _speed, 0, 1);

        if (_fade.a == 0)
            Destroy(this.gameObject);
    }
}