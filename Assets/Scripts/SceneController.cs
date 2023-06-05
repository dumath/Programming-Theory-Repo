using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject world;
    public float minPos;
    public float maxPos;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        world.transform.position = new Vector2(0f, minPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (world.transform.position.y <= maxPos)
            world.transform.position = new Vector2(0f, minPos);
        float offsetX = speed * Time.deltaTime;
        world.transform.Translate(0f, -speed, 0f);
    }
}
