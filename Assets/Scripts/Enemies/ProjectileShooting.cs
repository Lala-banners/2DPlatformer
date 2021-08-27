using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    [Header("Shooting Stats")]
    public float speed;
    private PlayerController2D player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start() {
        player = FindObjectOfType<PlayerController2D>();
        target = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(4f);
            gameObject.SetActive(false);
        }
    }
}
