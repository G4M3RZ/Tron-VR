using UnityEngine;

public class audioScript : MonoBehaviour {
	
	private static audioScript audio;

	void Awake () 
	{
		if(audio == null)
		{
			audio=this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}
}