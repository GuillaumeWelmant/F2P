using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : CardEffect {

    public int manaHeal;

    override public void Effect()
    {
        Player player = FindObjectOfType<Player>();
        player.GainMana(manaHeal);
    }
}
