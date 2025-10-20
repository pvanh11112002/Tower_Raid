using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

/// <summary>
/// CardView giữ vai trò một lá bài
/// </summary>
public class CardView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] SpriteRenderer front_SpriteRenderer;
    private Card card;
    public void InitCard(Card card)
    {
        this.card = card;
        front_SpriteRenderer.sprite = card.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        card.PerformEffect();
        Destroy(this.gameObject);
    }

    public void SetSortingOrder(int order)
    {
        front_SpriteRenderer.sortingOrder = order;
    }
    public void FaceUp()
    {
        gameObject.transform.DORotate(new Vector3(0, 0, 0), 0.5f);
    }
    public void FaceDown()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    }
