using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Card/New Card Data")]
[System.Serializable]
public class CardDataSO : ScriptableObject
{
    [SerializeField] public Sprite Sprite;
    [SerializeField] public int Value;
}
