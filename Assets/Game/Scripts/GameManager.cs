using UnityEngine;
using System;

public class GameManager : MonoBehaviour {
	[Serializable]
	public class Orb {
		protected int _total;
		protected int _collected;
		public int Total {
			get { return _total; }
			set { 
				if (_total != value && value > 0) Percentage = (float)_collected / value;
				_total = value;
			}
		}
		public int Collected {
			get { return _collected; }
			set { 
				if (_collected != value && _total > 0) Percentage = (float)value / _total;
				_collected = value;
			}
		}
		public float Percentage;
	}

	public Orb red = new Orb();
	public Orb green = new Orb();
	public Orb blue = new Orb();
		
	public bool paused = false;

	static GameManager instance;
	public static GameManager Instance { get { return instance; } }
	
	SaturationEffect saturationEffectScript;
	
	// Use this for initialization
	void Awake () {
		if (instance != null) {
			Debug.LogError("Already a GameManager(Singleton) in this scene; conflict between '" 
				+ instance.gameObject.name + "' and '" + gameObject.name);
			return;
		}
		instance = this;
		
		GameObject go = GameObject.FindGameObjectWithTag(Constants.BWCamera);
		if (go != null) {
			saturationEffectScript = go.GetComponent<SaturationEffect>();
		}
	}
	
	void Start () {
		PauseGame(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !paused)
		{
			PauseGame(true);
		}
		else if (Input.GetButtonDown("Fire1") && paused)
		{
			// unpause
			PauseGame(false);
		}
		
		// Update saturation
		if (saturationEffectScript != null) {
			saturationEffectScript.red = red.Percentage * 2;
			saturationEffectScript.green = green.Percentage;
			saturationEffectScript.blue = blue.Percentage * 2;
		}
	}
	
	void PauseGame(bool pause)
	{
		// show and unlock the cursor when paused
		Screen.lockCursor = !pause;
		Screen.showCursor = pause;
		
		// Slow the game down to virtually stopped on pause
		Time.timeScale = pause ? 0.00001f : 1.0f;
		
		// Show the pause menu
		UIManager.Instance.SetPauseMessageVisibility(pause);
		
		// Pause music
		
		
		paused = pause;
	}
}
