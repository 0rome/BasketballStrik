using UnityEngine;
using System.Collections;

public class ChaoticMovement : MonoBehaviour
{
    [SerializeField] private float movementRange = 1f;    // ��������� ������ ������ ����� ��������� �� ������
    [SerializeField] private float speed = 1f;            // �������� ��������� �������

    private Vector2 startPosition;
    private float noiseX;
    private float noiseY;

    void Start()
    {
        startPosition = transform.position;
        noiseX = Random.Range(0f, 100f); // ��������� ��������� ����� ����
        noiseY = Random.Range(0f, 100f);
    }

    void Update()
    {
        // ��������� ����������� ��������� ����, ����� ���������
        noiseX += Time.deltaTime * speed;
        noiseY += Time.deltaTime * speed;

        float x = Mathf.PerlinNoise(noiseX, 0f) * 2f - 1f;
        float y = Mathf.PerlinNoise(noiseY, 1f) * 2f - 1f;

        Vector2 offset = new Vector2(x, y) * movementRange;
        transform.position = startPosition + offset;
    }
}
