using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CarEnterExitVR : MonoBehaviour
{
    public Transform driverSeat; // Позиция водителя
    public GameObject car; // Машина
    public GameObject playerRig; // XR Rig (игрок)
    public GameObject playerModel; // Визуальная модель игрока (если есть)
    
    private bool isInCar = false; // Флаг, находится ли игрок в машине
    private CarController carController; // Ссылка на управление машиной

    void Start()
    {
        carController = car.GetComponent<CarController>();
    }

    public void EnterCar() // Вызывается при хвате двери
    {
        if (!isInCar)
        {
            playerRig.transform.position = driverSeat.position; // Перемещаем игрока
            playerRig.transform.rotation = driverSeat.rotation; // Выравниваем
            playerRig.GetComponent<CharacterController>().enabled = false; // Выключаем передвижение
            isInCar = true;
            carController.isPlayerInCar = true; // Включаем управление машиной
            
            if (playerModel != null)
                playerModel.SetActive(false); // Скрываем модель игрока
        }
    }

    public void ExitCar() // Вызывается кнопкой выхода (например, на руке)
    {
        if (isInCar)
        {
            playerRig.transform.position = car.transform.position + car.transform.right * 2; // Выход сбоку
            playerRig.GetComponent<CharacterController>().enabled = true;
            isInCar = false;
            carController.isPlayerInCar = false; // Отключаем управление машиной
            
            if (playerModel != null)
                playerModel.SetActive(true); // Включаем модель игрока
        }
    }
}
