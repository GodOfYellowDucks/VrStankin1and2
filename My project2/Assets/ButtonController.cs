using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject knopka;
    public GameObject spindel;
    public bool isOn = false;
    public Quaternion offRotation;
    public Quaternion onRotation;
    public float rotationSpeed = 5f;  // �������� �������� ������
    public float spindleSpeed = 1500f;  // ������������ �������� �������� �������� (����/���)
    public float currentSpindleSpeed = 0f;  // ������� �������� �������� ��������
    public float acceleration = 100f;  // ��������� ��������

    private void Start()
    {
        offRotation = Quaternion.Euler(0, 0, 0);
        onRotation = Quaternion.Euler(0, 0, -73);
    }

    private void Update()
    {
        // �������� �� ������� ������ ���� � �����������, ������ �� 'knopka'
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == knopka)
            {
                isOn = !isOn;  // ������������ ��������� ������
            }
        }

        // �������� ������ � ��������
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

        // ���������� �������� � �������� �� ��� X
        spindel.transform.Rotate(currentSpindleSpeed * Time.deltaTime, 0, 0);
    }
}
