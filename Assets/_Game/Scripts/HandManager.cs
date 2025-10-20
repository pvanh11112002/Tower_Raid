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

    [SerializeField] Transform handHolder;
    [SerializeField] Transform deckHolder;

    // SO List of Card Data
    [SerializeField] List<CardDataSO> cardDatas = new List<CardDataSO>();

    [SerializeField] List<CardView> decks = new List<CardView>();

    private List<CardView> handCards = new List<CardView>();

    private void Start()
    {
        InitDeck();
        StartCoroutine(InitHandCardCoroutine(maxHandSize));
    }
    private void InitDeck()
    {
        for (int i = 0; i < cardDatas.Count; i++)
        {
            Card cardData = new Card(cardDatas[i]);
            CardView card = Instantiate(cardPrefab, cardSpawnPos.position, Quaternion.identity/*, deckHolder*/);
            decks.Add(card);
            card.InitCard(cardData);
            card.FaceDown();
        }
    }
    private void GetRandomCardsFromDeck(int layer)
    {
        int randomIndex = Random.Range(0, decks.Count);
        CardView card = decks[randomIndex];
        decks.RemoveAt(randomIndex);
        handCards.Add(card);
        //card.transform.SetParent(handHolder);
        card.SetSortingOrder(layer);
    }
    IEnumerator InitHandCardCoroutine(int numberCardToDraw)
    {
        for (int i = 0; i < maxHandSize; i++)
        {
            GetRandomCardsFromDeck(i);
            UpdateCardPos();
            yield return new WaitForSeconds(0.2f);
        }
    }    
    private void UpdateCardPos()
    {
        if (handCards.Count == 0) return;
        float cardSpacing = 1f / maxHandSize;
        float firstCardPos = 0.5f - (cardSpacing * (handCards.Count - 1) / 2f);
        Spline spline = handSpline.Spline;
        for (int i = 0; i < handCards.Count; i++)
        {
            float t = firstCardPos + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(t);
            Vector3 forwad = spline.EvaluateTangent(t);
            Vector3 up = spline.EvaluateUpVector(t);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forwad).normalized);
            handCards[i].transform.DOMove(splinePosition, 0.25f);
            handCards[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
            handCards[i].FaceUp();
        }
    }    
}
