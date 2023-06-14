using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class CardGameManager : SingletonDestroy<CardGameManager>
{
    // Oyuncu ve rakip kartlarını temsil eden listeler
    public List<Card> playerHand;
    public GameObject playerCards;
    public List<Card> opponentHand;

    // Kartların yerleştirilebileceği slotları temsil eden dizi
    public GameObject[] playerSlots;
    public GameObject[] enemySlots;

    // Oyun durumu
    public bool playerTurn = true;

    private void Start()
    {
        for (int i = 0; i < playerCards.transform.childCount; i++)
        {
            playerCards.transform.GetChild(i).GetComponent<DragAndDrop>().dragCard = playerHand[i];
        }
    }

    public IEnumerator OpponentTurn()
    {
        yield return new WaitForSeconds(1.5f);
        
        Card cardToPlay = opponentHand[Random.Range(0, opponentHand.Count)];
        int emptySlotIndex = GetEmptySlotIndex(enemySlots);
        
        playerTurn = true;
        
        if (emptySlotIndex != -1)
        {
            enemySlots[emptySlotIndex].GetComponent<CardSlot>().PlaceCard(cardToPlay);
            opponentHand.Remove(cardToPlay);
        }
    }

    int GetEmptySlotIndex(GameObject[] slots)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<CardSlot>().isEmpty)
            {
                return i;
            }
        }
        return -1;
    }
}
