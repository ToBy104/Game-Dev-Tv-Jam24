using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    [SerializeField] private Transform ground;
    [SerializeField] private TimerManager timerManager;

    private List<Transform> groundCubes;

    private void Awake()
    {
        groundCubes = new List<Transform>();
        foreach (Transform t in ground) //Walk on Child
        {
            groundCubes.Add(t);
        }
    }

    private void OnEnable()
    {
        timerManager.onTimerEnd.AddListener(OnTimerEnd);
    }

    private void OnTimerEnd()
    {
        if (groundCubes.Count <= 0)
            return;

        int randomIndexBlock = Random.Range(0, groundCubes.Count);
        Transform temp = groundCubes[randomIndexBlock];

        groundCubes.Remove(temp);           //Remove from list
        EnableBlockTransition(temp);        //Enable script BlockTransition
    }

    private void EnableBlockTransition(Transform block)
    {
        BlockTransitionManager blockActiveTransition = block.gameObject.GetComponent<BlockTransitionManager>();
        if (blockActiveTransition != null)
        {
            blockActiveTransition.enabled = true;

        }
    }
}
