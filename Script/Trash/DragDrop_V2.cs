using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop_V2 : MonoBehaviour//, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    /*
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject designPanel;
    
    private RectTransform rectTransform;
    private RectTransform designPanelRectTransform; //design panel rectTransform
    private CanvasGroup canvasGroup;

    private Vector3 rectPosition = Vector3.zero;
    private bool isOutSide; //UI ?????? ?????? ?????? ???????? ????
    public bool isDrop = false; //?????? ?????????? ????
    public bool isStartBlock = false; //???? ???????? ????
    public GameObject slot; //?????? ???????? ????
    public RectTransform InputSlotRectTransform; //?????? ?????? ?????? RectTransform

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        designPanelRectTransform = designPanel.GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        // ???????? ?????????? ???? ???? ??????
        Vector3[] panelsCorners = new Vector3[4];
        designPanelRectTransform.GetWorldCorners(panelsCorners);

        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        //Rect rect = new Rect(corners[0].x, corners[1].y, rectTransform.rect.width, rectTransform.rect.height);

        Rect canvasRect = new Rect(panelsCorners[0], panelsCorners[2] - panelsCorners[0]);
        Rect rect = new Rect(corners[0], corners[2] - corners[0]);

        Vector2 minPosition = new Vector2(rect.xMin - canvasRect.xMin, rect.yMin - canvasRect.yMin);
        Vector2 maxPosition = new Vector2(rect.xMax - canvasRect.xMax, rect.yMax - canvasRect.yMax);

        // UI ?????? ?????? ?????? ???????? ????
        isOutSide = (minPosition.x < 0f) || (maxPosition.x > 0f) || (minPosition.y < 0f) || (maxPosition.y > 0f);
        //Debug.Log(isOutSide);
        //Debug.Log(isDrop);

        //?????? ?????? ???? ??
        if (isDrop)
        {
            try
            {
                this.GetComponent<RectTransform>().anchoredPosition = InputSlotRectTransform.anchoredPosition;
            }
            catch (MissingReferenceException e) //???? ?????? ???????? ???? ???? ???? ?????? ?????? ???? ???????? ??????
            {
                //Debug.Log(e.Message);
                InputSlotRectTransform = null;
                isDrop = false;
                this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            }
        }
    }

    //?????? ?????? ??
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        isDrop = false;

        rectPosition = rectTransform.position; //???????? ?????? ?? ????
        //Debug.Log(rectPosition);
        canvasGroup.alpha = 0.6f; //????????
        canvasGroup.blocksRaycasts = false;
    }

    //?????? ???? ???? ??
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //canvas?? scaleFactor ???? ???????? ??(?????? ???????? ????????) screen space - camera ????
    }

    //?????? ?????? ??
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        if (isOutSide)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = eventData.pointerDrag.GetComponent<DragDrop>().getPosition(); // ???? ???? ?????? ????
        }

        canvasGroup.alpha = 1f; //????????
        canvasGroup.blocksRaycasts = true;
    }
    //?????? ???????? ?????? ??
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPonterDown");
        //???????? ???????? ????
        this.GetComponent<RectTransform>().SetAsLastSibling(); //???????????? ?????? ?????????? ????(?????? ???? ???????? ??????)
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("DragDrop_OnDrop");
        //?????? ?????? ???? ??
        if (isDrop)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = eventData.pointerDrag.GetComponent<DragDrop>().getPosition(); // ???? ???? ?????? ????
        }
        //throw new System.NotImplementedException();
    }

    public void setCanvas(Canvas canvas)
    {
        this.canvas = canvas;
    }

    public Vector3 getPosition()
    {
        return rectPosition;
    }
    */
}
