using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardSlotUI : MonoBehaviour
{
    public CardSlot worldSlot;
    
    public Card _card;
    public Image _image;
    public TextMeshProUGUI _cardName;
    public TextMeshProUGUI _cardAttack;
    public TextMeshProUGUI _cardHealth;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _cardName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardAttack = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _cardHealth = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    public void AssignCard(Card card)
    {
        _card = card;
        _image.sprite = _card.backSide;
        _cardName.text = _card.monsterName;
        _cardAttack.text = _card.attack.ToString();
        _cardHealth.text = _card.health.ToString();
        
        worldSlot.PlaceCard(card);
    }
}

