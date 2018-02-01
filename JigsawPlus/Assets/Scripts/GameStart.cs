using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

	// Use this for initialization

	void Start () {
		
        IronSourceControl.Instance.ShowBanner();
	    IronSourceControl.Instance.LoadInterstitial();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnOkButtonClicked()
    {
        // AudioControl.Instance.PlayClickAudio();
        GameHelper.Instance.GameMode = GameHelper.EGameMode.TEN;
        CanvasControl.Instance.OnStartButtonClicked();
    }

}
