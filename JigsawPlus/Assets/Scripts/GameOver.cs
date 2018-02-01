using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField]
    private Image newRecord;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text bestText;

    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button homeButton;

    private bool isFreshScore = false;

    // Use this for initialization
    void Start () {

        restartButton.onClick.AddListener(OnRestartButtonClicked);
        homeButton.onClick.AddListener(OnHomeButtonClicked);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show(bool isFreshScore)
    {
        
        this.gameObject.SetActive(true);
        this.isFreshScore = isFreshScore;

        bestText.text = CanvasControl.Instance.Best.ToString();
        scoreText.text = CanvasControl.Instance.Score.ToString();

        CanvasControl.Instance.ClearAllPicGameObjectsOnDrag();
        CanvasControl.Instance.imageControl.ClearAllImageItemGameObjects();
        CanvasControl.Instance.ClearAllShapesGameObjects();
        CanvasControl.Instance.Score = 0;

        GameHelper.gameData.ShapeDictionary.Clear();

        newRecord.gameObject.SetActive(this.isFreshScore);

        restartButton.interactable = false;
        homeButton.interactable = false;

        StartCoroutine(DelayResetMap());

    }

    public void SetIsFreshScore(bool flag)
    {
        this.isFreshScore = flag;
    }

    public void OnRatePopUp()
    {
        if (isFreshScore)
        {
            GameHelper.Instance.popView.OnRatePopUp();
            this.isFreshScore = false;
        }
        
    }

    IEnumerator DelayResetMap()
    {
        yield return new WaitForSeconds(0.5f);

        GameHelper.gameData.ClearData();

        restartButton.interactable = true;
        homeButton.interactable = true;
    }

    public void OnRestartButtonClicked()
    {
        if (Random.Range(0.0f, 1.0f) < 0.3f)
        {
            //AdControl.Instance.ShowInterstitial();
        }

        CanvasControl.Instance.InitGame();

    }

    public void OnHomeButtonClicked()
    {
        AudioControl.Instance.PlayClickAudio();
        CanvasControl.Instance.BackToGameStart();

    }
}
