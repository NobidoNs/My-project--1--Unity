using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRMovement : MonoBehaviour
{
    public XRNode inputSource;  // Устанавливаем для левого или правого контроллера
    private InputDevice device;  // Устройство для получения ввода
    private CharacterController characterController;
    private Vector2 inputAxis;

    public float speed = 1.5f;  // Скорость передвижения
    public float rotationSpeed = 5f;  // Скорость поворота

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        device = InputDevices.GetDeviceAtXRNode(inputSource);
    }

    void Update()
    {
        if (!device.isValid)
        {
            device = InputDevices.GetDeviceAtXRNode(inputSource);
        }

        // Получаем ось движения с контроллера
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        // Перемещение вперед/назад и влево/вправ
        Vector3 moveDirection = new Vector3(inputAxis.x, 0, inputAxis.y);
        moveDirection = transform.TransformDirection(moveDirection); // Преобразуем в мировые координаты
        characterController.Move(moveDirection * speed * Time.deltaTime);

        // Поворот игрока в направлении движения
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
