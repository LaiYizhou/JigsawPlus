using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragOnPic : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //记录下自己的父物体.
    Transform myParent;

    //Panel，使拖拽是显示在最上方.
    Transform tempParent;

    CanvasGroup cg;
    RectTransform rt;

    //记录鼠标位置.
    Vector3 newPosition;

    private Canvas canvas;

    void Awake()
    {
        //添加CanvasGroup组件用于在拖拽是忽略自己，从而检测到被交换的图片.
        cg = this.gameObject.AddComponent<CanvasGroup>();

        rt = this.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        tempParent = GameObject.Find("Canvas").transform;
    }




    /// <summary>
    /// Raises the begin drag event.
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        //拖拽开始时记下自己的父物体.
        myParent = transform.parent;

        //拖拽开始时禁用检测.
        cg.blocksRaycasts = false;

        this.transform.SetParent(tempParent);
    }

    /// <summary>
    /// Raises the drag event.
    /// </summary>
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //cg.blocksRaycasts = false;
        //RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, Input.mousePosition, eventData.enterEventCamera, out newPosition);

        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, Input.mousePosition, canvas.worldCamera, out newPosition);

        transform.position = newPosition + CanvasControl.OFFSET_VECTOR3;
        //transform.position = newPosition;
        transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    }

    /// <summary>
    /// Raises the end drag event.
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {

        cg.blocksRaycasts = true;

        if (CanvasControl.Instance.imageControl.IsCanFill())
        {
            CanvasControl.Instance.imageControl.FillImage(this.gameObject.GetComponent<ShapeItem>());
            StartCoroutine(DelayDestroy());
        }
        else
        {
            int sourceIndex = this.gameObject.GetComponent<ShapeItem>().SourceIndex;

            transform.SetParent(CanvasControl.Instance._ShapeSourceTransformsList[sourceIndex]);
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
        }

    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForEndOfFrame();

        Destroy(this.gameObject);
    }

}