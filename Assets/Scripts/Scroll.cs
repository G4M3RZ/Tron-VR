using UnityEngine;

public class Scroll : MonoBehaviour {
	
	public float scrollx = 0.5f;
	public float scrolly = 0.5f;

	private Material _mat;
	private float timer;

	private void Awake()
	{
		_mat = GetComponent<Renderer>().material;
	}
	void Update ()
    {
		timer+=Time.deltaTime;

		float offsetX = timer * scrollx;
		float offsetY = timer * scrolly;
		_mat.mainTextureOffset = new Vector2 (offsetX, offsetY);
	}
}