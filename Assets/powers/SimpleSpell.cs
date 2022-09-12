using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpell : MonoBehaviour
{
    public int damage;
    public float speed;

    public Enemy closestEnemy;
    public Player player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - player.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.up, new Vector3(0, 0, closestEnemy.transform.position.z), singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);

        
        transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, singleStep);

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
