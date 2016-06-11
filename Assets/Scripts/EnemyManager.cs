using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    private const float HalfShip = 0.60f;
    private const float maxtime = 0.5f;
    [SerializeField]
    private float speed = 1;

    private float limits;
    private float direction = 1;
    private float lastdirection;
    [SerializeField]
    private enemy[] enemies;
    private float downTime;

    // Use this for initialization
    void Start () {
        limits = Camera.main.ViewportToWorldPoint(Vector3.right).x - HalfShip;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = Vector3.zero;
        if (direction == 0)
        {
            downTime += Time.deltaTime;
            velocity = Vector3.down * speed * Time.deltaTime;
            if (downTime>maxtime)
            {
                direction = -lastdirection;
                lastdirection = direction;
                downTime = 0;
            }
        }
        else
        {
             velocity = Vector3.right * speed * direction * Time.deltaTime;
        }
       

        foreach (enemy enemy in  enemies)
        {
            enemy.Move(velocity);
        }
        float deltaX=0;
        foreach (enemy enemy in enemies)
        {
            transform.Translate(velocity);

            float x = Mathf.Clamp(enemy.transform.position.x, -limits, limits);

            if (x !=enemy.transform.position.x)
            {
                deltaX = enemy.transform.position.x - x;
                direction=0;
                break;
            }
        }

        foreach (enemy enemy in enemies)
        {
            enemy.Move(new Vector3(-deltaX,0,0));
        }


    }
}
