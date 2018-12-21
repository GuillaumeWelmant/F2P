using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour, IBeginDragHandler, IPointerClickHandler, IDragHandler, IEndDragHandler {

    public Card card;

    public Text manaCostText;
    public Text nameText;
    public Text attackText;
    public Text healthText;
    public Image artworkImage;
    public Image patternImage;

    public static Card currentlyDraggedCard;

    private Vector3 startPos;


    // Use this for initialization
    void Start ()
    {
        DisplayCard();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayCard()
    {
        manaCostText.text = card.manaCost.ToString();
        nameText.text = card.name;
        attackText.text = card.attack.ToString();
        healthText.text = card.health.ToString();
        artworkImage.sprite = card.artwork;
        patternImage.sprite = card.pattern;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        GetComponent<Image>().raycastTarget = false;
        Debug.Log("Card : " + card.name + " dragged.");
        currentlyDraggedCard = card;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPos;
        currentlyDraggedCard = null;
        GetComponent<Image>().raycastTarget = true;
    }

    public void ResetPos()
    {
        transform.position = startPos;
    }
}
