using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    public TeamColor Team;
    public bool isEmpty = true;
    
    public Card _card;
    // public Image cardImage;
    public GameObject _monster;


    public void PlaceCard(Card card)
    {
        _card = card;
        
        // cardImage.sprite = card.backSide; //oynayisa gore on veya arka yuz gorunecek

        _monster = Instantiate(_card.monsterObject, transform);
        isEmpty = false;

        if (Team == TeamColor.Blue)
        {
            CardGameManager.Instance.playerTurn = false;
            CardGameManager.Instance.playerHand.Remove(card);

            CardGameManager.Instance.StartCoroutine("OpponentTurn");
        }
    }
    
}