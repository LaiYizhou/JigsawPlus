using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageItem : MonoBehaviour
{

    
    [HideInInspector]
    public Color NotFilledColor;
    [HideInInspector]
    public Color FilledColor;

    [SerializeField] private Image _image;
    [SerializeField] private Text _text;

    public int ImageId;
    private int filledColorId;
    public int FilledColorId
    {
        get
        {
            return filledColorId;
        }

        set
        {
            filledColorId = value;
            if (filledColorId >= 0 && filledColorId < (int) CanvasControl.ESpriteColor.Count)
            {
                IsFilled = true;
                _image.sprite = GameHelper.Instance.ColorSpritesList[(int)filledColorId];
            }
            else
            {
                IsFilled = false;
            }
        }
    }

    private bool _isFilled;
    public bool IsFilled
    {
        get
        {
            return _isFilled;
        }

        set
        {
            _isFilled = value;

            if(_isFilled)
                _image.color = FilledColor;
            else
                _image.color = NotFilledColor;
        }
    }

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FillImage(CanvasControl.ESpriteColor color)
    {
        FilledColorId = (int) color;
    }

    public void InitImage(int index)
    {
        FilledColorId = -1;

        ImageId = index;
        _text.text = ImageId.ToString();
        _text.gameObject.SetActive(false);

    }


    void OnTriggerStay2D(Collider2D coll)
    { 
       
        ShapeItem shapeItem = coll.gameObject.GetComponentInParent<ShapeItem>();

        if (shapeItem != null)
        {
            //Debug.Log(shapeItem.Shape + " IN BLOCK " + ImageId);

            //CanvasControl.Instance.imageControl.Reset();
            //CanvasControl.Instance.imageControl.SetToFilledImage(shapeItem.Shape, ImageId);
            CanvasControl.Instance.imageControl.SetToFilledImage(shapeItem, ImageId);
        }
        
    }

    void OnTriggerExit2D(Collider2D coll)
    {

        //CanvasControl.Instance.imageControl.RemoveImageIndex(ImageId);

        CanvasControl.Instance.imageControl.ToFilledImageList.Clear();

        //SetCyanColor();
        //CanvasControl.Instance.imageControl.Reset();
    }
}
