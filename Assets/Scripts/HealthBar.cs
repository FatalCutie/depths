using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthBarText;
    public Health characterHealth;

    void Update()
    {
        UpdateHealthBar(); //temp
    }

    public void UpdateHealthBar()
    {
        healthBar.maxValue = characterHealth.MaxHP;
        healthBar.value = characterHealth.CurrentHP;
        healthBarText.text = $"{characterHealth.CurrentHP}/{characterHealth.MaxHP}";
    }

}
