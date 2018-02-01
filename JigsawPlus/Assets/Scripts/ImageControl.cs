using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{

    public List<ImageItem> ImageItemsList;

    public int CurImageIndex;
    public int ToFilledImageNumber;

    // Show shapeItem.ExpandImageList for test
    public List<int> l = new List<int>();
    public List<int> ToFilledImageList;
    
    // Use this for initialization
    void Start()
    {
       
    }

    public void SetToFilledImage(ShapeItem shapeItem, int curImageIndex)
    {
        l.Clear();
        ToFilledImageList.Clear();
        ToFilledImageNumber = shapeItem.BlockNumber;

        if (shapeItem.ValueImageList.Contains(curImageIndex))
        {
            l = new List<int>(shapeItem.ExpandImageList);
            foreach (int offset in shapeItem.ExpandImageList)
            {
                AddImageIndex(curImageIndex + offset);
                CurImageIndex = curImageIndex;
            }
        }
        else
        {
            l.Clear();
        }
       
        
        
    }

    public bool IsCanFill()
    {

        if (ToFilledImageList.Count != ToFilledImageNumber)
            return false;

        try
        {
            for (int i = 0; i < ToFilledImageNumber; i++)
            {
                if (ImageItemsList[ToFilledImageList[i]].IsFilled)
                    return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
            throw;
        }
        

        return true;
    }

    public void FillImage(ShapeItem shapeItem)
    {
        //Debug.Log(" FillImage() " + color);
        AudioControl.Instance.PlayPlaceBlockAudio();
        StopCoroutine(CheckGameOver());

        GameHelper.gameData.ShapeDictionary.Remove(shapeItem.SourceIndex);

        if (GameHelper.gameData.ShapeDictionary.Count == 0)
        {
            Debug.Log("### ReBuild Three Shapes");
            CanvasControl.Instance.BuildShapeItem();
        }

        for (int i = 0; i < ToFilledImageList.Count; i++)
            ImageItemsList[ToFilledImageList[i]].FillImage(shapeItem.SpriteColor);

        CanvasControl.Instance.Score += shapeItem.BlockNumber;
        flag = 0;

        for (int i = 0; i < ToFilledImageList.Count; i++)
        {
            CheckRowAndColumnLine(ToFilledImageList[i]);
        }

        StartCoroutine(CheckGameOver());

        rowNumbers.Clear();
        columnNumbers.Clear();
    }


    public void CheckGameOverWhenInit()
    {
        StartCoroutine(CheckGameOver());
    }

    public void SaveMap()
    {

        Debug.Log("Saving Map...");
        GameHelper.gameData.SaveMap(ImageItemsList);        

    }

    private List<int> rowNumbers = new List<int>();
    private List<int> columnNumbers = new List<int>();

    private int flag = 0;

    public void CheckRowAndColumnLine(int curImageNumber)
    {

        int rowNumber = curImageNumber / GameHelper.SIZE;
        int columnNumber = curImageNumber - rowNumber * GameHelper.SIZE;

        bool isRowLineFull = false;
        bool isColumnLineFull = false;

        if (!rowNumbers.Contains(rowNumber))
        {
            isRowLineFull = CheckRowLine(rowNumber);
            rowNumbers.Add(rowNumber);
        }

        if (!columnNumbers.Contains(columnNumber))
        {
            isColumnLineFull = CheckColumnLine(columnNumber);
            columnNumbers.Add(columnNumber);
        }

        if (isRowLineFull)
        {
            flag = flag + GameHelper.SIZE;
            StartCoroutine(DelayRemoveRowLine(rowNumber));
        }

        if (isColumnLineFull)
        {
            flag = flag + GameHelper.SIZE;
            StartCoroutine(DelayRemoveColumnLine(columnNumber));
        }
        

    }

    IEnumerator CheckGameOver()
    {
        yield return new WaitUntil(()=>(flag == 0));
        StartCoroutine("DelaySaveMap");

        Debug.Log("####### Checking Game Over...");

        bool isGameOver = true;

        foreach (var pair in GameHelper.gameData.ShapeDictionary)
        {
            CanvasControl.EShape shape = (CanvasControl.EShape) pair.Value.shapeIndex;

            var validImageList = GameHelper.GetValidImageList(shape);
            var expandImageList = GameHelper.GetExpandImageList(shape);

            foreach (int validImageIndex in validImageList)
            {
                bool isAroundAllEmpty = true;

                for (int j = 0; j < expandImageList.Count; j++)
                {
                    if (ImageItemsList[validImageIndex + expandImageList[j]].IsFilled)
                    {
                        isAroundAllEmpty = false;
                        break;
                    }
                }

                if (isAroundAllEmpty)
                {
                    isGameOver = false;
                    break;
                }
            }
        }


        if (isGameOver)
        {
            Debug.Log("#### Game Over! the Map is: ####");
            CanvasControl.Instance.GameOver();
            yield return null;
        }

    }

    public void StopDelaySaveMap()
    {
        StopCoroutine("DelaySaveMap");
    }

    IEnumerator DelaySaveMap()
    {
        yield return new WaitForSeconds(0.3f);
        SaveMap();
    }


    public bool CheckRowLine(int rowNumber)
    {
        for (int i = rowNumber * GameHelper.SIZE; i < (1 + rowNumber) * GameHelper.SIZE; i++)
        {
            if (!ImageItemsList[i].IsFilled)
                return false;
        }

        return true;

    }

    IEnumerator DelayRemoveRowLine(int rowNumber)
    {
        yield return new WaitForSeconds(0.3f);
        AudioControl.Instance.PlayRemoveLinesAudio();

        //Debug.Log("Remove rowNumber = " + rowNumber);
        

        int i = rowNumber * GameHelper.SIZE;

        StartCoroutine(ShowRemoveRowLine(i, rowNumber));

        CanvasControl.Instance.Score += GameHelper.SIZE;
    }

    IEnumerator ShowRemoveRowLine(int i, int rowNumber)
    {
        yield return new WaitForSeconds(0.07f);

        if (i < (1 + rowNumber) * GameHelper.SIZE)
        {
            ImageItemsList[i].FilledColorId = -1;
            i++;

            flag--;
            //Debug.Log("Flag = " + flag);

            StartCoroutine(ShowRemoveRowLine(i, rowNumber));
        }

    }

    public bool CheckColumnLine(int columnNumber)
    {
        for (int i = columnNumber; i < GameHelper.SIZE * GameHelper.SIZE; i = i + GameHelper.SIZE)
        {
            if (!ImageItemsList[i].IsFilled)
                return false;
        }

        return true;
    }

    IEnumerator DelayRemoveColumnLine(int columnNumber)
    {
        yield return new WaitForSeconds(0.3f);
        AudioControl.Instance.PlayRemoveLinesAudio();

        Debug.Log("Remove columnNumber = " + columnNumber);
        

        StartCoroutine(ShowRemoveColumnLine(columnNumber));

        CanvasControl.Instance.Score += GameHelper.SIZE;
    }

    IEnumerator ShowRemoveColumnLine(int columnNumber)
    {
        yield return new WaitForSeconds(0.07f);

        if (columnNumber < GameHelper.SIZE * GameHelper.SIZE)
        {
            ImageItemsList[columnNumber].FilledColorId = -1;
            columnNumber = columnNumber + GameHelper.SIZE;

            flag--;
            //Debug.Log("Flag = " + flag);

            StartCoroutine(ShowRemoveColumnLine(columnNumber));
        }
    }

    public void AddImageIndex(int index)
    {
        if (!ToFilledImageList.Contains(index))
            ToFilledImageList.Add(index);
    }

    public void RemoveImageIndex(int index)
    {
        if (ToFilledImageList.Contains(index))
            ToFilledImageList.Remove(index);

        ImageItemsList[index].IsFilled = ImageItemsList[index].IsFilled;
    }

    public void Reset()
    {
        foreach (ImageItem imageItem in ImageItemsList)
        {
            RemoveImageIndex(imageItem.ImageId);
            imageItem.IsFilled = false;
        }
    }

    public void ClearAllImageItemGameObjects()
    {
        ImageItemsList.Clear();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

}
