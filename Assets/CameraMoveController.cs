using UnityEngine;

public class CameraTouchControl : MonoBehaviour
{
    // ���������������� �������� ������
    public float moveSpeed = 0.1f;

    // ������� ����������� �������
    private Vector3 lastTouchPosition;

    void Update()
    {
        // ��������� ������� ������� �� ������
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ���� ��������� ������ �������
            if (touch.phase == TouchPhase.Began)
            {
                // ���������� ������� �������
                lastTouchPosition = touch.position;
            }
            // ���� ��������� ����������� ������ �� ������
            else if (touch.phase == TouchPhase.Moved)
            {
                // ��������� ������� � ������� ����� ���������� � ������� ���������
                Vector3 deltaTouchPosition = lastTouchPosition - (Vector3)touch.position;

                // ���������� ������ �� ����������� � ������������ � ��������� ������ �� X ����������
                transform.Translate(deltaTouchPosition.x * moveSpeed * Time.deltaTime, 0, 0);

                // ���������� ������ �� ��������� � ������������ � ��������� ������ �� Y ����������
                transform.Translate(0, deltaTouchPosition.y * moveSpeed * Time.deltaTime, 0);

                // ���������� ������� �������� ������� ��� ������������ ������������� � ��������� �����
                lastTouchPosition = touch.position;
            }
        }
    }
}