using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//The fact I need this is really silly
public class ButtonColorSync : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image mainImage; // The main button image
    public Image childImage; // The child image to also tint
    public Color normalColor = Color.white;
    public Color highlightedColor = Color.gray;
    public Color pressedColor = Color.black;

    private void Reset()
    {
        mainImage = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetColor(highlightedColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetColor(normalColor);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SetColor(pressedColor);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SetColor(highlightedColor);
    }

    void SetColor(Color color)
    {
        if (mainImage) mainImage.color = color;
        if (childImage) childImage.color = color;
    }
}