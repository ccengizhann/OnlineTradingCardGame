using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    private bool isEmpty = true;

    public Card _card;
    public Image cardImage;
    public TextMeshProUGUI textName;
    

    public void PlaceCard(Card card)
    {
        if(card == null) Debug.Log("karta ulasilamadi....");

        _card = card;
        Debug.Log("card name " + card.name + " monster name " + card.monsterName);
        
        cardImage.sprite = card.backSide; //oynayisa gore on veya arka yuz gorunecek
        textName.text = card.monsterName;

        isEmpty = false;
    }
    
    public bool IsEmpty()
    {
        return isEmpty;
    }
}