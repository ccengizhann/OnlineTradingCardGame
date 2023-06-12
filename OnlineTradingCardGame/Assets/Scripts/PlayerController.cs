using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CardGame cardGame;
    private Card selectedCard;

    private void Awake()
    {
        cardGame = GetComponent<CardGame>();
    }
    
    public void SelectCard(int cardIndex)
    {
        if (cardGame.playerTurn)
        {
            selectedCard = cardGame.playerHand[cardIndex];
            CardSlot cardSlot = cardGame.playerSlots[cardIndex].GetComponent<CardSlot>();
            if (cardSlot.IsEmpty())
            {
                cardSlot.PlaceCard(selectedCard);
                // cardGame.playerHand.Remove(selectedCard);
                selectedCard = null;
                
                cardGame.playerTurn = false;
                StartCoroutine(cardGame.OpponentTurn());
            }
        }
        
    }
}