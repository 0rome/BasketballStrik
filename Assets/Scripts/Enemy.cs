using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Sprite[] changeSprites;
    [SerializeField] private float followSpeed = 2f;    // Скорость следования
    [SerializeField] private float chaosStrength = 1f;  // Сила хаотичного смещения
    [SerializeField] private float chaosSpeed = 1f;     // Скорость изменения шума
    [SerializeField] private bool isSurvival;


    [Header("Effects")]
    [SerializeField] private GameObject destroyEffectPrefab;

    private int state;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private Transform target;          // Цель (игрок)
    private float noiseX;
    private float noiseY;

    private void Awake()
    {
        if (isSurvival)
        {
            if (PlayerPrefs.GetString("Dif") == "Easy")
            {
                followSpeed = 10f;
                chaosSpeed = 15f;
                chaosSpeed = 5f;
            }
            else if (PlayerPrefs.GetString("Dif") == "Medium")
            {
                followSpeed = 15f;
                chaosSpeed = 20f;
                chaosSpeed = 10f;
            }
            else
            {
                followSpeed = 20f;
                chaosSpeed = 25f;
                chaosSpeed = 15f;
            }
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        RandomState();

        if (target == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }

        noiseX = Random.Range(0f, 100f);
        noiseY = Random.Range(0f, 100f);
    }
    private void RandomState()
    {
        state = Random.Range(0, 2);
        spriteRenderer.sprite = changeSprites[state];
    }
    void Update()
    {
        if (target == null) return;

        // Плавно увеличиваем координаты для шума
        noiseX += Time.deltaTime * chaosSpeed;
        noiseY += Time.deltaTime * chaosSpeed;

        // Смещение по Perlin Noise
        float offsetX = (Mathf.PerlinNoise(noiseX, 0f) * 2f - 1f) * chaosStrength;
        float offsetY = (Mathf.PerlinNoise(noiseY, 1f) * 2f - 1f) * chaosStrength;

        Vector2 chaosOffset = new Vector2(offsetX, offsetY);

        // Направление к игроку
        Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;

        // Обновляем позицию с учетом хаоса
        Vector2 newPosition = (Vector2)transform.position + direction * followSpeed * Time.deltaTime + chaosOffset * Time.deltaTime;

        transform.position = newPosition;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player.GetComponent<Player>().GetPlayerMode() == state)
            {
                player.GetComponent<Player>().PlayerAnim();
                player.GetComponent<Player>().GetScorePoint();
                SoundManager.Instance.MakeSound(1);
                Destroy(gameObject);
            }
            else
            {
                player.GetComponent<Player>().Death();
                CameraShake.Shake(0.5f,0.1f);
            }
        }
    }
}
