using UnityEngine;

public class SpindleControl : MonoBehaviour
{
    public GameObject spindle;
    public GameObject lever;
    public float[] speeds = { 0f, 100f, 200f, 300f };  // �������� ��� ������ �������
    private int currentGear = 0;  // ������� ��������

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // �������� ����� ����� ������� ����
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "knopka")  // ��������, ��� �������� ������ �� ������
                {
                    hit.transform.Rotate(0, 0, 40);  // ������� ������ �� 40 ��������
                    spindle.transform.Rotate(0, 0, speeds[currentGear] * Time.deltaTime);
                }
            }
        }

        // ��������� �������� �������
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentGear < speeds.Length - 1)
        {
            currentGear++;
            lever.transform.Rotate(0, 0, -10);  // ������� ������ ��� ���������� ��������
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentGear > 0)
        {
            currentGear--;
            lever.transform.Rotate(0, 0, 10);  // ������� ������ ��� ���������� ��������
        }
    }
}
