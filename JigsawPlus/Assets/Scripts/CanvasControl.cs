using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{

    public static CanvasControl Instance;

    public static Vector3 OFFSET_VECTOR3 = new Vector3(0.0f, 20.0f, 0.0f);

    public enum EShape
    {
       
        Shape20 = 20,
        
        Shape21 = 21,
        Shape22 = 22,

        Shape23 = 23,
        Shape24 = 24,
        Shape25 = 25,
        Shape26 = 26,
        Shape27 = 27,
        Shape28 = 28,

        Shape29 = 29,
        Shape30 = 30,
        Shape31 = 31,

        Shape32 = 32,
        Shape33 = 33,
        Shape34 = 34,
        Shape35 = 35,
        Shape36 = 36,
        Shape37 = 37,

        Shape38 = 38,

        Count

    }
    public enum ESpriteColor
    {
        Yellow = 0,
        Green,
        Grass,
        Red,
        Orange,

        Count
    }

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _bestText;
    [SerializeField]
    private Button menuButton;
    [SerializeField]
    private Image chessBoard;



    [SerializeField]
    private GameObject noMove;
    private Vector2 noMoveOriginalPos;

    public List<Transform> _ShapeSourceTransformsList;   

    public ImageControl imageControl;
    public GameOver gameOver;
    public GameStart gameStart;

    public bool isFreshScore;

    private int score;
    public int Score
    {
        get { return PlayerPrefs.HasKey("Score") ? PlayerPrefs.GetInt("Score") : 0; }
        set
        {
            score = value;

            if (score >= Best)
            {
                isFreshScore = true;
                Best = score;
            }
            PlayerPrefs.SetInt("Score", score);
            _scoreText.text = score.ToString();
        }
    }

    private int best;
    public int Best
    {
        get { return PlayerPrefs.HasKey("Best") ? PlayerPrefs.GetInt("Best") : 0; }

        set
        {
            best = value;
            PlayerPrefs.SetInt("Best", best);
            _bestText.text = best.ToString();
        }
    }



    // Use this for initialization
    IEnumerator Start()
    {

        yield return new WaitForEndOfFrame();

        Instance = this;

        gameOver.gameObject.SetActive(false);
        gameStart.gameObject.SetActive(true);

        noMoveOriginalPos = noMove.GetComponent<RectTransform>().anchoredPosition;

        menuButton.onClick.AddListener(OnMenuButtonClicked);

    }

    public void InitGame()
    {
        AudioControl.Instance.PlayClickAudio();

        if (!IronSource.Agent.isInterstitialReady())
            IronSourceControl.Instance.LoadInterstitial();

        gameOver.gameObject.SetActive(false);
        gameStart.gameObject.SetActive(false);

        Score = Score;
        Best = Best;
        isFreshScore = false;
        gameOver.SetIsFreshScore(isFreshScore);

        noMove.GetComponent<RectTransform>().anchoredPosition = noMoveOriginalPos;

        BuildImagesItem();
        LoadBoolMap();

        BuildShapeItem();

        imageControl.CheckGameOverWhenInit();

    }

    public void ClearAllShapesGameObjects()
    {
        for (int i = 0; i < _ShapeSourceTransformsList.Count; i++)
        {
            for(int j = 0; j < _ShapeSourceTransformsList[i].childCount; j++)
                Destroy(_ShapeSourceTransformsList[i].GetChild(j).gameObject);
        }
        
    }

    void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            if (!IronSource.Agent.isInterstitialReady())
                IronSourceControl.Instance.LoadInterstitial();
        }
        else
        {
            if (IronSourceControl.Instance != null)
            {
                IronSourceControl.Instance.ShowInterstitial(1.0f);
                StartCoroutine(DelayInitInterstitial());
            }
        }
    }

    IEnumerator DelayInitInterstitial()
    {
        yield return new WaitForSeconds(15.0f);

        if (!IronSource.Agent.isInterstitialReady())
        {
            Debug.Log("DelayInitInterstitial : false");
            IronSourceControl.Instance.LoadInterstitial();
        }
        else
        {
            Debug.Log("DelayInitInterstitial : true");
        }

    }

    public void OnMenuButtonClicked()
    {
        AudioControl.Instance.PlayClickAudio();

        if (PlayerPrefs.HasKey("NotFirstMenuButtonClicked"))
        {

            IronSourceControl.Instance.ShowInterstitial(0.7f);
            StartCoroutine(DelayInitInterstitial());
        }
        else
            PlayerPrefs.SetInt("NotFirstMenuButtonClicked", 1);

        BackToGameStart();
    }

    public void BackToGameStart()
    {
        gameOver.gameObject.SetActive(false);
        gameStart.gameObject.SetActive(true);

        imageControl.StopDelaySaveMap();
        imageControl.ClearAllImageItemGameObjects();
        ClearAllShapesGameObjects();

        IronSourceControl.Instance.ShowInterstitial(1.0f);
    }

    public void BuildImagesItem()
    {

        imageControl.ImageItemsList.Clear();

        GameObject goPrefab = Resources.Load("ImageItem") as GameObject;

        for (int i = 0; i < GameHelper.SIZE * GameHelper.SIZE; i++)
        {

            GameObject go = Instantiate(goPrefab);
            go.transform.SetParent(imageControl.transform);
            go.transform.localScale = Vector3.one;

            go.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(GameHelper.Instance.MapPosList[i].x,
                GameHelper.Instance.MapPosList[i].y, 0.0f);

            ImageItem imageItem = go.GetComponent<ImageItem>();
            imageItem.InitImage(i);

            imageControl.ImageItemsList.Add(imageItem);
        }
      
    }

    public void LoadBoolMap()
    {
        if (GameHelper.gameData.MapDictionary != null & imageControl.ImageItemsList != null)
        {
            for (int i = 0; i < GameHelper.SIZE * GameHelper.SIZE; i++)
            {
                imageControl.ImageItemsList[i].FilledColorId = GameHelper.gameData.MapDictionary[i];
            }
        }
    }

    public void BuildShapeItem()
    {

        if (GameHelper.gameData.ShapeDictionary.Count <= 0 || GameHelper.gameData.ShapeDictionary == null)
        {
            for (int i = 0; i < 3; i++)
            {
                var shapeIndex = 0;
                shapeIndex = Random.Range(20, 39);
                //index = 6;

                GameObject goPrefab = Resources.Load("Shapes/ShapeItem" + shapeIndex) as GameObject;

                int colorIndex = Random.Range(0, (int)ESpriteColor.Count);

                if (_ShapeSourceTransformsList[i].childCount == 0)
                {
                    GameObject go = Instantiate(goPrefab);
                    go.transform.SetParent(_ShapeSourceTransformsList[i]);
                    go.transform.localPosition = Vector3.zero;
                    go.transform.localScale = Vector3.one;

                    ShapeItem shapeItem = go.GetComponent<ShapeItem>();
                    shapeItem.SetShapeItem((EShape)shapeIndex, (ESpriteColor)colorIndex, i);

                    if (GameHelper.gameData.ShapeDictionary.Count <= 3)
                        GameHelper.gameData.AddShape(i, shapeIndex, colorIndex);

                }

            }
        }
        else
        {

            foreach (var pair in GameHelper.gameData.ShapeDictionary)
            {
                int sourceIndex = pair.Value.sourceIndex;
                int shapeIndex = pair.Value.shapeIndex;
                int colorIndex = pair.Value.colorIndex;

                GameObject goPrefab = Resources.Load("Shapes/ShapeItem" + shapeIndex) as GameObject;

                GameObject go = Instantiate(goPrefab);
                go.transform.SetParent(_ShapeSourceTransformsList[sourceIndex]);
                go.transform.localPosition = Vector3.zero;
                go.transform.localScale = Vector3.one;

                ShapeItem shapeItem = go.GetComponent<ShapeItem>();
                shapeItem.SetShapeItem((EShape)shapeIndex, (ESpriteColor)colorIndex, sourceIndex);

            }

        }

    }

    public void ClearAllPicGameObjectsOnDrag()
    {
        DragOnPic[] res = transform.GetComponentsInChildren<DragOnPic>();

        for (int i = 0; i < res.Length; i++)
            Destroy(res[i].gameObject);
    }

    public void OnStartButtonClicked()
    {
		if (PlayerPrefs.HasKey ("NotFirstStartGame")) 
		{
		        IronSourceControl.Instance.ShowInterstitial(0.3f);
		        StartCoroutine(DelayInitInterstitial());
		}
        else
            PlayerPrefs.SetInt("NotFirstStartGame", 1);

        GameHelper.Instance.InitMapPos();
        InitGame();
    }

    public void GameOver()
    {
        AudioControl.Instance.PlayGameOverAudio();

        Sequence uiMoveSequence = DOTween.Sequence();
        uiMoveSequence.Append(noMove.transform.gameObject.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 0.6f)
        );

        uiMoveSequence.AppendCallback(() =>
            StartCoroutine(DelayShowGameOver())
        );
   
    }

    IEnumerator DelayShowGameOver()
    {
        yield return new WaitForSeconds(0.5f);

        gameOver.gameObject.SetActive(true);
        gameOver.Show(isFreshScore);

    }

}
