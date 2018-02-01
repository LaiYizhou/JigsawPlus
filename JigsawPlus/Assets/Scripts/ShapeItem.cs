using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeItem : MonoBehaviour
{

    public CanvasControl.EShape Shape;
    public CanvasControl.ESpriteColor SpriteColor;

    public int SourceIndex;

    public int BlockNumber
    {
        get { return ExpandImageList.Count; }
    }

    public List<int> ValueImageList = new List<int>();
    public List<int> ExpandImageList = new List<int>();

    public Image[] Images;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetShapeItem(CanvasControl.EShape shape, CanvasControl.ESpriteColor color, int sourceIndex)
    {
        Shape = shape;
        SpriteColor = color;
        SourceIndex = sourceIndex;

        ValueImageList = GameHelper.GetValidImageList(shape);
        ExpandImageList = GameHelper.GetExpandImageList(shape);

        Images = this.transform.GetComponentsInChildren<Image>();

        //Debug.Log("@@@" + Images.Length);

        if (Images.Length == ExpandImageList.Count + 1)
        {
            for (int i = 1; i < Images.Length; i++)
                Images[i].sprite = GameHelper.Instance.ColorSpritesList[(int)color];
        }
        
    }
}
