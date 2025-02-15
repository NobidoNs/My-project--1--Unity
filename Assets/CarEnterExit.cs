using UnityEngine;

public class CarEnterExit : MonoBehaviour
{
    public Transform driverSeat; // Позиция водителя
    public GameObject car; // Машина
    public GameObject player; // Игрок (XR Rig)
    public GameObject playerModel; // Визуальная модель игрока (если есть)

    private bool isInCar = false; // Флаг, сидит ли игрок в машине

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Кнопка "E" для входа/выхода
        {
            if (isInCar)
            {
                ExitCar();
            }
            else
            {
                EnterCar();
            }
        }
    }

    void EnterCar()
    {   
        car.GetComponent<CarController>().isPlayerInCar = true;
        player.transform.position = driverSeat.position; // Перемещаем игрока в кресло
        player.transform.rotation = driverSeat.rotation; // Выравниваем поворот
        player.GetComponent<CharacterController>().enabled = false; // Отключаем коллизию игрока
        isInCar = true;

        if (playerModel != null)
            playerModel.SetActive(false); // Скрываем модель игрока (если есть)
    }

    void ExitCar()
    {   
        car.GetComponent<CarController>().isPlayerInCar = false;
        player.transform.position = car.transform.position + car.transform.right * 2; // Выход сбоку
        player.GetComponent<CharacterController>().enabled = true; // Включаем коллизию игрока
        isInCar = false;

        if (playerModel != null)
            playerModel.SetActive(true); // Включаем модель игрока (если есть)
    }
}
