using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;

    [SerializeField] private int platforms;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    private bool _left;
    private List<bool> _spawnedPlatformsOffset;

        // Start is called before the first frame update
    void Start()
    {
        _spawnedPlatformsOffset = new List<bool>();
        for (int i = 0; i < platforms; i++)
        {
            GameObject platform = Instantiate(platformPrefab);
            if (_left) platform.transform.position = new Vector3(-xOffset, yOffset * i) +transform.position;
            else platform.transform.position = new Vector3(xOffset, yOffset * i) + transform.position;
            
            platform.GetComponent<Platform>().IsLeft = _left;

            _spawnedPlatformsOffset.Add(_left);

            if (i >= 2 && _spawnedPlatformsOffset[i - 1] == _spawnedPlatformsOffset[i])
            {
                _left = !_spawnedPlatformsOffset[i - 1];
            }
            else
            {
                _left = Random.Range(0, 100) % 2 == 0;
            }
        }
        
    }
}
