using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

/// <summary>
/// CardView giữ vai trò một lá bài
/// </summary>
public class CardView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] SortingGroup front_SortingGr;

    [SerializeField] private SpriteRenderer cardSpriteRenderer;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI cost;
    private Card card;
    public void InitCard(Card card)
    {
        this.card = card;
        cardSpriteRenderer.sprite = card.sprite;
        title.text = card.cardName;
        cost.text = card.Cost.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        card.PerformEffect();
        Destroy(this.gameObject);
    }

    public void SetSortingOrder(int order)
    {
        front_SortingGr.sortingOrder = order;
    }
}
