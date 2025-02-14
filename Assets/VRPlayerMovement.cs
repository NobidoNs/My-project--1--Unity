using UnityEngine;
using UnityEngine.InputSystem;

public class VRPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform vrCamera;  // Ссылка на VR-камеру
    public InputActionAsset inputActions;  // Ссылка на Input Action Asset

    public float speed = 2.0f;    // Скорость перемещения
    public float gravity = -9.81f; // Гравитация
    private Vector3 velocity;      // Вектор скорости
    private InputAction moveAction;  // Действие для перемещения

    void Start()
    {
        // Получаем действие Move из Input Actions
        var actionMap = inputActions.FindActionMap("PlayerActions");
        moveAction = actionMap?.FindAction("Move");

        if (moveAction == null)
        {
            Debug.LogError("Action 'Move' не найден в PlayerActions!");
        }
        moveAction?.Enable();

        // Получаем CharacterController
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController отсутствует на объекте Player!");
        }
    }

    void Update()
    {
        if (moveAction == null || controller == null || vrCamera == null)
        {
            return; // Если что-то не настроено, не выполняем код
        }

        // Чтение значения с стикеров
        Vector2 input = moveAction.ReadValue<Vector2>();

        // Двигаем персонажа в направлении взгляда
        Vector3 moveDirection = vrCamera.forward * input.y + vrCamera.right * input.x;
        moveDirection.y = 0; // Сбрасываем Y, чтобы не прыгать
        controller.Move(moveDirection * speed * Time.deltaTime);

        // Гравитация
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
