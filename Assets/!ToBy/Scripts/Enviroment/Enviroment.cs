using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    [SerializeField] private Transform ground;


    private List<Transform> groundCubes;

    [Space(10)]
    [SerializeField] private float startTimer;
    float timer;

    private void Awake()
    {
        timer = startTimer;

        groundCubes = new List<Transform>();
        foreach (Transform t in ground)
            groundCubes.Add(t);
    }

    private void Update()
    {
        if (groundCubes.Count <= 0)
            return;
        if (timer <= 0)
        {
            int random = Random.Range(0, groundCubes.Count);
            Transform temp = groundCubes[random];

            groundCubes.Remove(temp);
            Destroy(temp.gameObject);

            timer = startTimer;
        }
        else
            timer -= Time.deltaTime;
    }
}
