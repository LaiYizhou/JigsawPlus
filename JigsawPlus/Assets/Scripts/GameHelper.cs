using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{

    public static GameHelper Instance;

    #region LIST

    public static List<int> Shape20ValidImageList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
        10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
        20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
        30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
        40, 41, 42, 43 ,44, 45, 46, 47, 48, 49,
        50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
        60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
        70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
        80, 81, 82, 83, 84, 85, 86, 87, 88, 89,
        90, 91, 92, 93, 94, 95, 96, 97, 98, 99 };

    public static List<int> Shape21ValidImageList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9,
        11, 12, 13, 14, 15, 16, 17, 18, 19,
        21, 22, 23, 24, 25, 26, 27, 28, 29,
        31, 32, 33, 34, 35, 36, 37, 38, 39,
        41, 42, 43 ,44, 45, 46, 47, 48, 49,
        51, 52, 53, 54, 55, 56, 57, 58, 59,
        61, 62, 63, 64, 65, 66, 67, 68, 69,
        71, 72, 73, 74, 75, 76, 77, 78, 79,
        81, 82, 83, 84, 85, 86, 87, 88, 89,
        91, 92, 93, 94, 95, 96, 97, 98, 99 };

    public static List<int> Shape22ValidImageList = new List<int>() {
        10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
        20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
        30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
        40, 41, 42, 43 ,44, 45, 46, 47, 48, 49,
        50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
        60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
        70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
        80, 81, 82, 83, 84, 85, 86, 87, 88, 89,
        90, 91, 92, 93, 94, 95, 96, 97, 98, 99 };

    public static List<int> Shape23ValidImageList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8,
        11, 12, 13, 14, 15, 16, 17, 18,
        21, 22, 23, 24, 25, 26, 27, 28,
        31, 32, 33, 34, 35, 36, 37, 38,
        41, 42, 43 ,44, 45, 46, 47, 48,
        51, 52, 53, 54, 55, 56, 57, 58,
        61, 62, 63, 64, 65, 66, 67, 68,
        71, 72, 73, 74, 75, 76, 77, 78,
        81, 82, 83, 84, 85, 86, 87, 88,
        91, 92, 93, 94, 95, 96, 97, 98, };

    public static List<int> Shape24ValidImageList = new List<int>() {
        10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
        20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
        30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
        40, 41, 42, 43 ,44, 45, 46, 47, 48, 49,
        50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
        60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
        70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
        80, 81, 82, 83, 84, 85, 86, 87, 88, 89 };

    public static List<int> Shape25ValidImageList = new List<int>() {
        11, 12, 13, 14, 15, 16, 17, 18, 19,
        21, 22, 23, 24, 25, 26, 27, 28, 29,
        31, 32, 33, 34, 35, 36, 37, 38, 39,
        41, 42, 43 ,44, 45, 46, 47, 48, 49,
        51, 52, 53, 54, 55, 56, 57, 58, 59,
        61, 62, 63, 64, 65, 66, 67, 68, 69,
        71, 72, 73, 74, 75, 76, 77, 78, 79,
        81, 82, 83, 84, 85, 86, 87, 88, 89,
        91, 92, 93, 94, 95, 96, 97, 98, 99 };

    public static List<int> Shape26ValidImageList = new List<int>() {
        11, 12, 13, 14, 15, 16, 17, 18, 19,
        21, 22, 23, 24, 25, 26, 27, 28, 29,
        31, 32, 33, 34, 35, 36, 37, 38, 39,
        41, 42, 43 ,44, 45, 46, 47, 48, 49,
        51, 52, 53, 54, 55, 56, 57, 58, 59,
        61, 62, 63, 64, 65, 66, 67, 68, 69,
        71, 72, 73, 74, 75, 76, 77, 78, 79,
        81, 82, 83, 84, 85, 86, 87, 88, 89,
        91, 92, 93, 94, 95, 96, 97, 98, 99 };

    public static List<int> Shape27ValidImageList = new List<int>() {
        11, 12, 13, 14, 15, 16, 17, 18, 19,
        21, 22, 23, 24, 25, 26, 27, 28, 29,
        31, 32, 33, 34, 35, 36, 37, 38, 39,
        41, 42, 43 ,44, 45, 46, 47, 48, 49,
        51, 52, 53, 54, 55, 56, 57, 58, 59,
        61, 62, 63, 64, 65, 66, 67, 68, 69,
        71, 72, 73, 74, 75, 76, 77, 78, 79,
        81, 82, 83, 84, 85, 86, 87, 88, 89,
        91, 92, 93, 94, 95, 96, 97, 98, 99 };

    public static List<int> Shape28ValidImageList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9,
        11, 12, 13, 14, 15, 16, 17, 18, 19,
        21, 22, 23, 24, 25, 26, 27, 28, 29,
        31, 32, 33, 34, 35, 36, 37, 38, 39,
        41, 42, 43 ,44, 45, 46, 47, 48, 49,
        51, 52, 53, 54, 55, 56, 57, 58, 59,
        61, 62, 63, 64, 65, 66, 67, 68, 69,
        71, 72, 73, 74, 75, 76, 77, 78, 79,
        81, 82, 83, 84, 85, 86, 87, 88, 89 };

    public static List<int> Shape29ValidImageList = new List<int>() { 1, 2, 3, 4, 5, 6, 7,
        11, 12, 13, 14, 15, 16, 17,
        21, 22, 23, 24, 25, 26, 27,
        31, 32, 33, 34, 35, 36, 37,
        41, 42, 43 ,44, 45, 46, 47,
        51, 52, 53, 54, 55, 56, 57,
        61, 62, 63, 64, 65, 66, 67,
        71, 72, 73, 74, 75, 76, 77,
        81, 82, 83, 84, 85, 86, 87,
        91, 92, 93, 94, 95, 96, 97 };

    public static List<int> Shape30ValidImageList = new List<int>() {
        20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
        30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
        40, 41, 42, 43 ,44, 45, 46, 47, 48, 49,
        50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
        60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
        70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
        80, 81, 82, 83, 84, 85, 86, 87, 88, 89 };

    public static List<int> Shape31ValidImageList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9,
        11, 12, 13, 14, 15, 16, 17, 18, 19,
        21, 22, 23, 24, 25, 26, 27, 28, 29,
        31, 32, 33, 34, 35, 36, 37, 38, 39,
        41, 42, 43 ,44, 45, 46, 47, 48, 49,
        51, 52, 53, 54, 55, 56, 57, 58, 59,
        61, 62, 63, 64, 65, 66, 67, 68, 69,
        71, 72, 73, 74, 75, 76, 77, 78, 79,
        81, 82, 83, 84, 85, 86, 87, 88, 89 };

    public static List<int> Shape32ValidImageList = new List<int>() {
        20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
        30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
        40, 41, 42, 43 ,44, 45, 46, 47, 48, 49,
        50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
        60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
        70, 71, 72, 73, 74, 75, 76, 77, 78, 79, };

    public static List<int> Shape33ValidImageList = new List<int>() { 2, 3, 4, 5, 6, 7,
        12, 13, 14, 15, 16, 17,
        22, 23, 24, 25, 26, 27,
        32, 33, 34, 35, 36, 37,
        42, 43 ,44, 45, 46, 47,
        52, 53, 54, 55, 56, 57,
        62, 63, 64, 65, 66, 67,
        72, 73, 74, 75, 76, 77,
        82, 83, 84, 85, 86, 87,
        92, 93, 94, 95, 96, 97 };

    public static List<int> Shape34ValidImageList = new List<int>() {
        22, 23, 24, 25, 26, 27, 28, 29,
        32, 33, 34, 35, 36, 37, 38, 39,
        42, 43 ,44, 45, 46, 47, 48, 49,
        52, 53, 54, 55, 56, 57, 58, 59,
        62, 63, 64, 65, 66, 67, 68, 69,
        72, 73, 74, 75, 76, 77, 78, 79,
        82, 83, 84, 85, 86, 87, 88, 89,
        92, 93, 94, 95, 96, 97, 98, 99 };

    public static List<int> Shape35ValidImageList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7,
        10, 11, 12, 13, 14, 15, 16, 17,
        20, 21, 22, 23, 24, 25, 26, 27,
        30, 31, 32, 33, 34, 35, 36, 37,
        40, 41, 42, 43 ,44, 45, 46, 47,
        50, 51, 52, 53, 54, 55, 56, 57,
        60, 61, 62, 63, 64, 65, 66, 67,
        70, 71, 72, 73, 74, 75, 76, 77 };

    public static List<int> Shape36ValidImageList = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9,
        12, 13, 14, 15, 16, 17, 18, 19,
        22, 23, 24, 25, 26, 27, 28, 29,
        32, 33, 34, 35, 36, 37, 38, 39,
        42, 43 ,44, 45, 46, 47, 48, 49,
        52, 53, 54, 55, 56, 57, 58, 59,
        62, 63, 64, 65, 66, 67, 68, 69,
        72, 73, 74, 75, 76, 77, 78, 79 };

    public static List<int> Shape37ValidImageList = new List<int>() {
        20, 21, 22, 23, 24, 25, 26, 27,
        30, 31, 32, 33, 34, 35, 36, 37,
        40, 41, 42, 43 ,44, 45, 46, 47,
        50, 51, 52, 53, 54, 55, 56, 57,
        60, 61, 62, 63, 64, 65, 66, 67,
        70, 71, 72, 73, 74, 75, 76, 77,
        80, 81, 82, 83, 84, 85, 86, 87,
        90, 91, 92, 93, 94, 95, 96, 97 };

    public static List<int> Shape38ValidImageList = new List<int>() {
        11, 12, 13, 14, 15, 16, 17, 18,
        21, 22, 23, 24, 25, 26, 27, 28,
        31, 32, 33, 34, 35, 36, 37, 38,
        41, 42, 43 ,44, 45, 46, 47, 48,
        51, 52, 53, 54, 55, 56, 57, 58,
        61, 62, 63, 64, 65, 66, 67, 68,
        71, 72, 73, 74, 75, 76, 77, 78,
        81, 82, 83, 84, 85, 86, 87, 88, };



    public static List<int> BlockExpandImageList = new List<int>() {0, 1, -7, -6};

    public static List<int> Bulge1ExpandImageList = new List<int>() {0, 1, -7, -1};
    public static List<int> Bulge2ExpandImageList = new List<int>() {0, -6, -7, -8};
    public static List<int> Bulge3ExpandImageList = new List<int>() {0, -7, 7, 1};
    public static List<int> Bulge4ExpandImageList = new List<int>() {0, 8, -6, 1};

    public static List<int> HorizonBarExpandImageList = new List<int>() {0, -1, -2, 1};
    public static List<int> VerticalBarExpandImageList = new List<int>() {0, 7, 14, 21};

    public static List<int> Corner1ExpandImageList = new List<int>() { 0, -1, 14, 7 };
    public static List<int> Corner2ExpandImageList = new List<int>() { 0, -1, 13, 6 };
    public static List<int> Corner3ExpandImageList = new List<int>() { 0, -1, -8, -15 };
    public static List<int> Corner4ExpandImageList = new List<int>() { 0, -1, -7, -14 };

    public static List<int> Seat1ExpandImageList = new List<int>() { 0, -1, -8, 7 };
    public static List<int> Seat2ExpandImageList = new List<int>() { 0, -7, -1, 6 };
    public static List<int> Seat3ExpandImageList = new List<int>() { 0, -7, -8, 1 };
    public static List<int> Seat4ExpandImageList = new List<int>() { 0, -7, -8, -6 };

    // 10x10
    public static List<int> Shape20ExpandImageList = new List<int>(){ 0 };

    public static List<int> Shape21ExpandImageList = new List<int>() { 0 , -1};
    public static List<int> Shape22ExpandImageList = new List<int>() { 0, -10 };

    public static List<int> Shape23ExpandImageList = new List<int>() { 0, -1, 1 };
    public static List<int> Shape24ExpandImageList = new List<int>() { 0, -10, 10 };
    public static List<int> Shape25ExpandImageList = new List<int>() { 0, -1, -10 };
    public static List<int> Shape26ExpandImageList = new List<int>() { 0, -10, -11 };
    public static List<int> Shape27ExpandImageList = new List<int>() { 0, -1, -11 };
    public static List<int> Shape28ExpandImageList = new List<int>() { 0, -1, 9 };

    public static List<int> Shape29ExpandImageList = new List<int>() { 0, -1, 1, 2 };
    public static List<int> Shape30ExpandImageList = new List<int>() { 0, 10, -10, -20 };
    public static List<int> Shape31ExpandImageList = new List<int>() { 0, -1, 9, 10 };

    public static List<int> Shape32ExpandImageList = new List<int>() { 0, -10, -20, 10, 20 };
    public static List<int> Shape33ExpandImageList = new List<int>() { 0, -1, -2, 1, 2 };
    public static List<int> Shape34ExpandImageList = new List<int>() { 0, -1, -2, -10, -20 };
    public static List<int> Shape35ExpandImageList = new List<int>() { 0, 1, 2, 10, 20 };
    public static List<int> Shape36ExpandImageList = new List<int>() { 0, -1, -2, 10, 20 };
    public static List<int> Shape37ExpandImageList = new List<int>() { 0, 1, 2, -10, -20 };

    public static List<int> Shape38ExpandImageList = new List<int>() { 0, -11, -10, -9, -1, 1, 9, 10, 11 };


    #endregion

    public PopupView popView;

    public List<Sprite> ColorSpritesList = new List<Sprite>();

    private Vector2[,] MapPos;
    [HideInInspector]
    public List<Vector2> MapPosList = new List<Vector2>();

    public enum EGameMode
    {
        SEVEN,
        TEN
    }

    public EGameMode GameMode;

    public static Vector2 StartPos
    {
        get
        {
            if(GameHelper.Instance.GameMode == EGameMode.SEVEN)
                return new Vector2(-264.5f, 264.5f);
            else
                return new Vector2(-282.0f, 279.0f);
        }
    }
    public static float Offset
    {
        get
        {
            if (GameHelper.Instance.GameMode == EGameMode.SEVEN)
                return 87.5f;
            else
                return 62.3f;
        }
    }

    public static int SIZE = 10;

    public static GameData gameData;

    public bool IsBannerSwitchOn;
    public bool IsInterstitialSwitchOn;

    // Use this for initialization
    void Start ()
    {
        GameMode = EGameMode.TEN;

        Debug.Log("Application.persistentDataPath = " + Application.persistentDataPath);
        gameData = new GameData();

        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitMapPos()
    {
        MapPosList.Clear();
        MapPos = new Vector2[GameHelper.SIZE, GameHelper.SIZE];

        for (int x = 0; x < GameHelper.SIZE; x++)
        for (int y = 0; y < GameHelper.SIZE; y++)
        {
            MapPos[x, y] = new Vector2(StartPos.x + Offset * y, StartPos.y - Offset * x);
            MapPosList.Add(MapPos[x, y]);
        }
    }

    public void OpenAppStore()
    {
        Debug.Log("GameHelper.OpenAppStore() ...");
        popView.OnOpenAppStore();
    }

    #region BitMap

    public string GetBitString(int value, int sLength = 7)
    {
        StringBuilder sb = new StringBuilder();
        for (var i = 0; i < sLength; i++)
        {
            var val = 1 << i;
            sb.Append((value & val) == val ? '1' : '0');
        }

        string res = new string(sb.ToString().ToCharArray().Reverse().ToArray());
        return res;
    }

    public int GetValue(string s)
    {
        int res = 0;
        if (s.Length <= 31)
        {
            int w = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                res += (s[i] == '0') ? 0 : w;
                w *= 2;
            }
        }

        return res;
    }

    #endregion

    public static List<int> GetExpandImageList(CanvasControl.EShape eShape)
    {
        switch (eShape)
        {
                case CanvasControl.EShape.Shape20:
                    return Shape20ExpandImageList;
                case CanvasControl.EShape.Shape21:
                    return Shape21ExpandImageList;
                case CanvasControl.EShape.Shape22:
                    return Shape22ExpandImageList;
                case CanvasControl.EShape.Shape23:
                    return Shape23ExpandImageList;
                case CanvasControl.EShape.Shape24:
                    return Shape24ExpandImageList;
                case CanvasControl.EShape.Shape25:
                    return Shape25ExpandImageList;
                case CanvasControl.EShape.Shape26:
                    return Shape26ExpandImageList;
                case CanvasControl.EShape.Shape27:
                    return Shape27ExpandImageList;
                case CanvasControl.EShape.Shape28:
                    return Shape28ExpandImageList;
                case CanvasControl.EShape.Shape29:
                    return Shape29ExpandImageList;
                case CanvasControl.EShape.Shape30:
                    return Shape30ExpandImageList;
                case CanvasControl.EShape.Shape31:
                    return Shape31ExpandImageList;
                case CanvasControl.EShape.Shape32:
                    return Shape32ExpandImageList;
                case CanvasControl.EShape.Shape33:
                    return Shape33ExpandImageList;
                case CanvasControl.EShape.Shape34:
                    return Shape34ExpandImageList;
                case CanvasControl.EShape.Shape35:
                    return Shape35ExpandImageList;
                case CanvasControl.EShape.Shape36:
                    return Shape36ExpandImageList;
                case CanvasControl.EShape.Shape37:
                    return Shape37ExpandImageList;
                case CanvasControl.EShape.Shape38:
                    return Shape38ExpandImageList;

                default:
                    return Seat4ExpandImageList;
        }
    }

    public static List<int> GetValidImageList(CanvasControl.EShape eShape)
    {
        switch (eShape)
        {
                
                case CanvasControl.EShape.Shape20:
                    return Shape20ValidImageList;
                case CanvasControl.EShape.Shape21:
                    return Shape21ValidImageList;
                case CanvasControl.EShape.Shape22:
                    return Shape22ValidImageList;
                case CanvasControl.EShape.Shape23:
                    return Shape23ValidImageList;
                case CanvasControl.EShape.Shape24:
                    return Shape24ValidImageList;
                case CanvasControl.EShape.Shape25:
                    return Shape25ValidImageList;
                case CanvasControl.EShape.Shape26:
                    return Shape26ValidImageList;
                case CanvasControl.EShape.Shape27:
                    return Shape27ValidImageList;
                case CanvasControl.EShape.Shape28:
                    return Shape28ValidImageList;
                case CanvasControl.EShape.Shape29:
                    return Shape29ValidImageList;
                case CanvasControl.EShape.Shape30:
                    return Shape30ValidImageList;
                case CanvasControl.EShape.Shape31:
                    return Shape31ValidImageList;
                case CanvasControl.EShape.Shape32:
                    return Shape32ValidImageList;
                case CanvasControl.EShape.Shape33:
                    return Shape33ValidImageList;
                case CanvasControl.EShape.Shape34:
                    return Shape34ValidImageList;
                case CanvasControl.EShape.Shape35:
                    return Shape35ValidImageList;
                case CanvasControl.EShape.Shape36:
                    return Shape36ValidImageList;
                case CanvasControl.EShape.Shape37:
                    return Shape37ValidImageList;
                case CanvasControl.EShape.Shape38:
                    return Shape38ValidImageList;
                default:
                        return Shape38ValidImageList;
        }
    }
}

public class Pos2
{
    public int X;
    public int Y;

    public Pos2() { }
    public Pos2(int x, int y) { X = x; Y = y; }
    public Pos2(Pos2 pos)
    {
        X = pos.X;
        Y = pos.Y;
    }

    public bool Equals(Pos2 pos)
    {
        if (X == pos.X)
            if (Y == pos.Y)
                return true;
        return false;
    }

    public bool Xequals(Pos2 pos)
    {
        if (X == pos.X)
            return true;
        return false;
    }
    public bool Yequals(Pos2 pos)
    {
        if (Y == pos.Y)
            return true;
        return false;
    }
    public override string ToString()
    {
        return "(" + X + "," + Y + ")";
    }
}