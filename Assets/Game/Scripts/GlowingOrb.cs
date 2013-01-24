using UnityEngine;

public class GlowingOrb : MonoBehaviour {
	public int redAward;
	public int greenAward;
	public int blueAward;
	
	// Use this for initialization
	void Start () {
		GameManager.Instance.red.Total += redAward;
		GameManager.Instance.green.Total += greenAward;
		GameManager.Instance.blue.Total += blueAward;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
    void OnTriggerEnter(Collider other) {
		//Debug.Log("Collided with " + other.name);
		if (!string.Equals(other.gameObject.tag, Constants.Player, System.StringComparison.OrdinalIgnoreCase)) return;
		
        GameManager.Instance.red.Collected += redAward;
		GameManager.Instance.green.Collected += greenAward;
		GameManager.Instance.blue.Collected += blueAward;
		
		GameObject.Destroy(gameObject);
    }	
}
