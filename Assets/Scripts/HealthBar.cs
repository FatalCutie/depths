using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthBarText;
    public Health characterHealth;
    public GameObject fillArea;

    void Update()
    {
        UpdateHealthBar(); //temp
    }

    public void UpdateHealthBar()
    {
        if (healthBar.value == 0)
        {
            if (fillArea.activeSelf) fillArea.SetActive(false);
            return;
        }
        healthBar.maxValue = characterHealth.MaxHP;
        healthBar.value = characterHealth.CurrentHP;
        healthBarText.text = $"{characterHealth.CurrentHP}/{characterHealth.MaxHP}";
    }

}
