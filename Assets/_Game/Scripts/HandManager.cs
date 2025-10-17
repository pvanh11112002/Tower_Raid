using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class HandManager : MonoBehaviour
{
    [SerializeField] int maxHandSize;
    [SerializeField] CardView cardPrefab;
    [SerializeField] SplineContainer handSpline;
    [SerializeField] Transform cardSpawnPos;

    // SO List of Card Data
    [SerializeField] List<CardDataSO> cardDatas = new List<CardDataSO>();

    [SerializeField] List<CardView> decks = new List<CardView>();

    private List<CardView> handCards = new List<CardView>();

    private void Start()
    {
        InitDeck();
        //StartCoroutine(InitHandCardCoroutine());
    }
    private void InitDeck()
    {
        for (int i = 0; i < cardDatas.Count; i++)
        {
            Card cardData = new Card(cardDatas[i]);
            CardView card = Instantiate(cardPrefab, cardSpawnPos.position, Quaternion.identity);
            decks.Add(card);
            card.InitCard(cardData);
        }
    }
    //IEnumerator InitHandCardCoroutine()
    //{
    //    for (int i = 0; i < maxHandSize; i++)
    //    {
    //        InitCard();
    //        UpdateCardPos();
    //        yield return new WaitForSeconds(0.2f);
    //    }
    //}
    private void InitCard()
    {
        //CardView card = Instantiate(cardPrefab, cardSpawnPos.position, Quaternion.identity);      
        //handCards.Add(card);
        //card.SetSortingOrder(handCards.Count);
    }     
    private void UpdateCardPos()
    {
        //if(handCards.Count == 0) return;
        //float cardSpacing = 1f / maxHandSize;
        //float firstCardPos = 0.5f - (cardSpacing * (handCards.Count - 1) / 2f);
        //Spline spline = handSpline.Spline;
        //for(int i = 0; i < handCards.Count; i++)
        //{
        //    float t = firstCardPos + i * cardSpacing;
        //    Vector3 splinePosition = spline.EvaluatePosition(t);
        //    Vector3 forwad = spline.EvaluateTangent(t);
        //    Vector3 up = spline.EvaluateUpVector(t);
        //    Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forwad).normalized);
        //    handCards[i].transform.DOMove(splinePosition, 0.25f);
        //    handCards[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        //}
    }    
}
