using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private Vector3 startPos;

    public float speed = 5f;

    public bool canAttack;

    [SerializeField] GameObject particleVFX;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (canAttack)
        {
            Vector3 destination = GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].GetPosOfNearestEnemy();

            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            canAttack = false;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].enemies.Remove(collision.gameObject);
            
            GameObject explosion = Instantiate(particleVFX, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(explosion, .75f);
            collision.gameObject.SetActive(false);

            transform.position = startPos;
        }
    }
}
