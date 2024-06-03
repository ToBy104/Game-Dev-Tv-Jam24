using System.Collections;
using UnityEngine;

public class BlockTransitionManager : MonoBehaviour
{
    [Header("blocks Prefabs")]
    [SerializeField] private GameObject redBlockPrefab;
    [SerializeField] private GameObject breakBlockPrefab;


    [Space(20)]

    [Header("Variables")]
    [SerializeField] private int _currentIndex = 0;

    private void Start()
    {

        StartCoroutine(TransitionBlocks());
    }

    private IEnumerator TransitionBlocks()
    {
        while (true)
        {

            yield return new WaitForSeconds(1f);


            TransitionToNextBlock();


            if (_currentIndex == 2)
            {
                yield return new WaitForSeconds(3f);
                Destroy(gameObject);
                yield break;
            }
        }
    }

    private void TransitionToNextBlock()
    {
        GameObject nextBlockPrefab = null;

        switch (_currentIndex)
        {
            case 0:
                nextBlockPrefab = redBlockPrefab;
                break;
            case 1:
                nextBlockPrefab = breakBlockPrefab;
                break;
        }

        if (nextBlockPrefab != null)
        {
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;


            Destroy(gameObject);

            GameObject newBlock = Instantiate(nextBlockPrefab, position, rotation);


            _currentIndex++;
        }
    }
}
