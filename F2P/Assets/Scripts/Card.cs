﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New  Card", menuName = "Card")]
public class Card : ScriptableObject {

    public enum Rarity { common, rare, epic, legendry}

    public new string name;

    public int manaCost;
    public Sprite artwork;
    public Sprite pattern;

    public int health;
    public int attack;

    public CardEffect effect;

    public float cooldown;

    public Rarity rarity;
}
