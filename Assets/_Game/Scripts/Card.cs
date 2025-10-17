using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Card
{
    private readonly CardDataSO cardData;

    // Những cái này không đổi nên để trả trực tiếp được
    public Sprite sprite { get => cardData.Sprite; }
    public string cardName { get => cardData.CardName; }

    // Cái này có thay đổi trong runtime nên để set được
    public int Cost { get; set; }
    public string Effect { get; set; }
    public Card(CardDataSO data)
    {
        this.cardData = data;
        Cost = cardData.Cost;
        Effect = cardData.Effect;
    }
    
    public void PerformEffect()
    {
        Debug.Log($"Performing effect of card: {cardName} - Effect: {Effect}");
    }    
}
