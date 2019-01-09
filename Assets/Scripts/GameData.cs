using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;

public class GameData
{
    private static string filePath
    {
        get
        {
            return Application.persistentDataPath + "/Data.xml";
        }
    }

    public Dictionary<int, int> MapDictionary;
    public Dictionary<int, ShapeInfo> ShapeDictionary;
    public bool IsContinue;

    public GameData()
    {
        MapDictionary = new Dictionary<int, int>();
        ShapeDictionary = new Dictionary<int, ShapeInfo>();

        if (File.Exists(filePath))
        {
            Debug.Log("Exists ! ! !");
            LoadPlayerData();
        }
        else
        {
            Debug.Log("Not Exists ! ! !");
            for (int i = 0; i < GameHelper.SIZE * GameHelper.SIZE; i++)
                MapDictionary.Add(i, -1);

            IsContinue = false;

            Save();
        }

    }

    private void LoadPlayerData()
    {
        XDocument xDocument = XDocument.Load(filePath);
        XElement gameData = xDocument.Root;

        Debug.Log("Start to sync gameData...");
        try
        {

            this.IsContinue = gameData.Attribute("isContinue").Value.Equals("true");

            foreach (var shapeInfo in xDocument.Descendants("ShapeInfo"))
            {
                int sourceIndex = int.Parse(shapeInfo.Attribute("sourceIndex").Value);
                int shapeIndex = int.Parse(shapeInfo.Attribute("shapeIndex").Value);
                int colorIndex = int.Parse(shapeInfo.Attribute("colorIndex").Value);

                this.ShapeDictionary.Add(sourceIndex, new ShapeInfo(sourceIndex, shapeIndex, colorIndex));

            }

            foreach (var chessInfo in xDocument.Descendants("ChessInfo"))
            {

                int chessId = int.Parse(chessInfo.Attribute("chessId").Value);
                int colorIndex = int.Parse(chessInfo.Attribute("colorIndex").Value);

                this.MapDictionary.Add(chessId, colorIndex);

            }




            Debug.Log("Sync PlayerData Successfully ! ! ! ");
        }
        catch (Exception e)
        {
            Debug.LogError("Fail to Sync PlayerData ! " + e);
        }
                
    }

    private void Save()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }  

        XDocument xDocument = new XDocument();
        XElement gameDataXElement = new XElement("GameData");

        XAttribute isContinueXAttribute = this.IsContinue ? new XAttribute("isContinue", "true") : new XAttribute("isContinue", "false");

        gameDataXElement.Add(isContinueXAttribute);

        foreach (var pair in ShapeDictionary)
        {
            XElement shapeInfo = new XElement("ShapeInfo");

            XAttribute sourceIndex = new XAttribute("sourceIndex", pair.Value.sourceIndex);
            XAttribute shapeIndex = new XAttribute("shapeIndex", pair.Value.shapeIndex);
            XAttribute colorIndex = new XAttribute("colorIndex", pair.Value.colorIndex);

            shapeInfo.Add(sourceIndex, shapeIndex, colorIndex);
            gameDataXElement.Add(shapeInfo);
        }

        foreach (var pair in MapDictionary)
        {
            XElement chapterInfo = new XElement("ChessInfo");

            XAttribute chessIdXAttribute = new XAttribute("chessId", pair.Key);
            XAttribute colorXAttribute = new XAttribute("colorIndex", pair.Value);

            chapterInfo.Add(chessIdXAttribute, colorXAttribute);
            gameDataXElement.Add(chapterInfo);

        }

        xDocument.Add(gameDataXElement);
        xDocument.Save(filePath);
    }

    public void SaveMap(List<ImageItem> list)
    {
        if (list.Count == GameHelper.SIZE * GameHelper.SIZE)
        {
            MapDictionary.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                MapDictionary.Add(list[i].ImageId, list[i].FilledColorId);
            }
        }

        Save();
        Debug.Log("Save Map Successfully ! ! !");
    }

    public void ResetMap()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public void AddShape(int sourceIndex, int shapeIndex, int colorIndex)
    {
        ShapeInfo shapeInfo = new ShapeInfo(sourceIndex, shapeIndex, colorIndex);
        if (ShapeDictionary.ContainsKey(sourceIndex))
        {
            ShapeDictionary[sourceIndex] = shapeInfo;
        }
        else
        {
            ShapeDictionary.Add(sourceIndex, shapeInfo);
        }

        Save();
    }

    public void RemoveShape(int sourceIndex)
    {
        if (ShapeDictionary.ContainsKey(sourceIndex))
            ShapeDictionary.Remove(sourceIndex);
    }

    public void ClearData()
    {
        MapDictionary.Clear();
        ShapeDictionary.Clear();

        for (int i = 0; i < GameHelper.SIZE * GameHelper.SIZE; i++)
            MapDictionary.Add(i, -1);

        Save();
    }


}

public class ShapeInfo
{
    public int sourceIndex;
    public int shapeIndex;
    public int colorIndex;

    public ShapeInfo(int sourceIndex, int shapeIndex, int colorIndex)
    {
        this.sourceIndex = sourceIndex;
        this.shapeIndex = shapeIndex;
        this.colorIndex = colorIndex;
    }

    public ShapeInfo()
    {
    }

}