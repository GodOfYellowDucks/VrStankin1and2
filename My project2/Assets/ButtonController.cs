using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject knopka;
    public GameObject spindel;
    public bool isOn = false;
    public Quaternion offRotation;
    public Quaternion onRotation;
    public float rotationSpeed = 5f;  // Скорость вращения кнопки
    public float spindleSpeed = 1500f;  // Максимальная скорость вращения шпинделя (град/сек)
    public float currentSpindleSpeed = 0f;  // Текущая скорость вращения шпинделя
    public float acceleration = 100f;  // Ускорение шпинделя

    private void Start()
    {
        offRotation = Quaternion.Euler(0, 0, 0);
        onRotation = Quaternion.Euler(0, 0, -73);
    }

    private void Update()
    {
        // Проверка на нажатие кнопки мыши и определение, нажата ли 'knopka'
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == knopka)
            {
                isOn = !isOn;  // Переключение состояния кнопки
            }
        }

        // Вращение кнопки и шпинделя
        if (isOn)
        {
            knopka.transform.localRotation = Quaternion.Lerp(knopka.transform.localRotation, onRotation, Time.deltaTime * rotationSpeed);
            currentSpindleSpeed = Mathf.Lerp(currentSpindleSpeed, spindleSpeed, Time.deltaTime * acceleration);
        }
        else
        {
            knopka.transform.localRotation = Quaternion.Lerp(knopka.transform.localRotation, offRotation, Time.deltaTime * rotationSpeed);
            currentSpindleSpeed = Mathf.Lerp(currentSpindleSpeed, 0, Time.deltaTime * acceleration);
        }

        // Приложение вращения к шпинделю по оси X
        spindel.transform.Rotate(currentSpindleSpeed * Time.deltaTime, 0, 0);
    }
}
