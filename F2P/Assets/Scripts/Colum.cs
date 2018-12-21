using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Colum : MonoBehaviour, IDropHandler {

    public Player player;
    
    public Transform startPos;

    public void OnDrop(PointerEventData eventData)
    {
        Card c = CardDisplay.currentlyDraggedCard;
        if(player.GetMana() >= c.manaCost)
        {
            player.LoseMana(c.manaCost);
            c.effect.Effect(startPos, c.attack, c.health);
            player.UseCard(c);
        }
    }
}
