using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedcoins;
    public GameManager gm;
    private float timer;
    public int timeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 20)
        {
            Destroy(gameObject);
        }
        rb.velocity = Vector2.left * (speedcoins + gm.speedMultiplier);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gm.CurrentScore += 10;
            Destroy(gameObject);
        }
    }
}
