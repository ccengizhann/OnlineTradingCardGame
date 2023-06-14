using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card Game/Card")]
public class Card : ScriptableObject
{
    public string monsterName;
    public GameObject monsterObject;
    public Sprite frontSide;
    public Sprite backSide;
    
    public int attack;
    public int health;
    public int cost;
}
