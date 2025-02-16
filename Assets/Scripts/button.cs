using UnityEngine;
using UnityEngine.UI;

public class VRButtonScript : MonoBehaviour
{
    private Button button;
    private Color originalColor;
    private Image buttonImage;

    void Start()
    {
        // Получаем компонент Button
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        // Получаем компонент Image, если есть
        buttonImage = GetComponent<Image>();
        if (buttonImage != null)
        {
            originalColor = buttonImage.color;
        }
    }

    void OnButtonClick()
    {
        Debug.Log("VR-кнопка нажата!");

        // Меняем цвет кнопки
        if (buttonImage != null)
        {
            buttonImage.color = Color.green;
            Invoke("ResetColor", 0.5f); // Возвращаем цвет через 0.5 секунды
        }
    }

    void ResetColor()
    {
        if (buttonImage != null)
        {
            buttonImage.color = originalColor;
        }
    }
}
