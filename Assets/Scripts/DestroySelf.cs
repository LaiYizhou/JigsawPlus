using UnityEngine;

public class DestroySelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.localScale.x <= 0.01 || this.transform.localPosition.y < -1400.0f)
            Destroy(this.gameObject);
	}
}
