using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class CardGame : MonoBehaviour
{
    // Oyuncu ve rakip kartlarını temsil eden listeler
    public List<Card> playerHand;
    public List<Card> opponentHand;

    // Kartların yerleştirilebileceği slotları temsil eden dizi
    public GameObject[] playerSlots;
    public GameObject[] enemySlots;

    // Oyun durumu
    public bool playerTurn = true;
    

    public IEnumerator OpponentTurn()
    {
        yield return new WaitForSeconds(1.5f);
        
        Card cardToPlay = opponentHand[Random.Range(0, opponentHand.Count)];
        int emptySlotIndex = GetEmptySlotIndex(enemySlots);
        
        playerTurn = true;
        
        if (emptySlotIndex != -1)
        {
            enemySlots[emptySlotIndex].GetComponent<CardSlot>().PlaceCard(cardToPlay);
            // opponentHand.Remove(cardToPlay);
        }
    }

    int GetEmptySlotIndex(GameObject[] slots)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<CardSlot>().IsEmpty())
            {
                return i;
            }
        }
        return -1;
    }
}
