using Mono.CompilerServices.SymbolWriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private CanvasGroup canvasGroup;
    [HideInInspector] public Transform parentAfterDrag;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        parentAfterDrag = transform.parent;
        transform.SetParent(GameObject.Find("UI").transform);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
       // rectTransform.anchoredPosition += eventData.delta; ///canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        transform.SetParent(parentAfterDrag);


    }

    public void OnPointerDown(PointerEventData enventData)
    {
        
    }
}
