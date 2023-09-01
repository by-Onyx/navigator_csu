using UnityEngine;

public class CameraTouchControl : MonoBehaviour
{
    // Чувствительность движения камеры
    public float moveSpeed = 0.1f;

    // Позиция предыдущего касания
    private Vector3 lastTouchPosition;

    void Update()
    {
        // Проверяем наличие касания на экране
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Если произошло начало касания
            if (touch.phase == TouchPhase.Began)
            {
                // Запоминаем позицию касания
                lastTouchPosition = touch.position;
            }
            // Если произошло перемещение пальца по экрану
            else if (touch.phase == TouchPhase.Moved)
            {
                // Вычисляем разницу в позиции между предыдущим и текущим касаниями
                Vector3 deltaTouchPosition = lastTouchPosition - (Vector3)touch.position;

                // Перемещаем камеру по горизонтали в соответствии с движением пальца по X координате
                transform.Translate(deltaTouchPosition.x * moveSpeed * Time.deltaTime, 0, 0);

                // Перемещаем камеру по вертикали в соответствии с движением пальца по Y координате
                transform.Translate(0, deltaTouchPosition.y * moveSpeed * Time.deltaTime, 0);

                // Запоминаем позицию текущего касания для последующего использования в следующем кадре
                lastTouchPosition = touch.position;
            }
        }
    }
}