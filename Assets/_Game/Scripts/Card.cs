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
    public int Value { get; set; }
    public Card(CardDataSO data)
    {
        this.cardData = data;
        Value = cardData.Value;
    }
    
    public void PerformEffect()
    {
        Debug.Log($"The value of this card is {Value}");
    }    
}
