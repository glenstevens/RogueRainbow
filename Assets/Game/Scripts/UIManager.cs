using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	static UIManager _instance;
	public static UIManager Instance { get { return _instance; } }
	
	//public UILabel scoreLabel;
	public UILabel pauseMessage;
	
	void Awake()
	{
		_instance = this;
	}
	
//	public void UpdateScore(int newScore)
//	{
//		if (scoreLabel == null) return;
//		scoreLabel.text = newScore.ToString("D8");
//	}
	
	public void SetPauseMessageVisibility(bool visible)
	{
		if (pauseMessage == null) return;
		NGUITools.SetActive(pauseMessage.gameObject, visible);
	}
}
