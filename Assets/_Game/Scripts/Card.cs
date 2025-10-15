using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] bool isFlipped = false;

    [SerializeField] GameObject backFace; 
    [SerializeField] GameObject frontFace;

    [Header("Holding Card Config")]
    [SerializeField] float holdingCardHighY = 50f;
    [SerializeField] float holdingCardDuration = 0.15f;
    [SerializeField] Ease holdingCardHighEase = Ease.Linear;
    [Header("-------------------")]
    [SerializeField] float holdingCardScale = 1.1f;
    [SerializeField] Ease holdingCardScaleEase = Ease.Linear;


    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isFlipped) FlipCard();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHoldingCard();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        OffHoldingCard();
    }
    private void FlipCard()
    {
        isFlipped = true;
        gameObject.transform.DOScaleX(-1, 0.25f);
    }
    private void OnHoldingCard()
    {
        backFace.transform.DOLocalMoveY(holdingCardHighY, holdingCardDuration).SetEase(holdingCardHighEase);
        backFace.transform.DOScale(holdingCardScale, holdingCardDuration).SetEase(holdingCardScaleEase);
    }    
    private void OffHoldingCard()
    {
        backFace.transform.DOLocalMoveY(0f, 0);
        backFace.transform.DOScale(1f, 0);
    }

    
}
