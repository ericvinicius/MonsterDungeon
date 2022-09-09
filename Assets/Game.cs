using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public SpriteRenderer enemySprite;
    public List<SpriteRenderer> enemies;

    public int initial_enemies;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initial_enemies; i++)
        {
            int x = Random.Range(-50, 50);
            int y = Random.Range(-50, 50);
            Instantiate(enemySprite, new Vector3(x, y, -1), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
