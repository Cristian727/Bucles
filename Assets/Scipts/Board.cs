using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int boardWidth;
    [SerializeField] int boardHeight;
    [SerializeField] float timeBetweenSpawns;
    int numberTiles;
    Vector3 position;

    [SerializeField] float timeBetweenAnimations;
    [SerializeField] float xRotationScaler;
    [SerializeField] float yRotationScaler;

    [SerializeField] float xColorScaler;
    [SerializeField] float yColorScaler;


    List<TileScript> tiles = new List<TileScript>();





    void Start()
    {
        StartCoroutine(BoardSpawn());
        StartCoroutine(TileAnimation());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BoardSpawn()
    {
        for (int i = 0; i <= boardWidth - 1; i++)
            for (int j = 0; j <= boardHeight - 1; j++)
            {
                position = new Vector3(i, 0, j);

                instantiate(position);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

    }

    IEnumerator TileAnimation()
    {
        int current = 0;

        while (tiles.Count == 0)
            yield return null;

        while (true)
        {
            tiles[current].Animation();
            current = ++current % tiles.Count;

            yield return new WaitForSeconds(timeBetweenAnimations);
        }


    }

    void instantiate(Vector3 position)
    {

        GameObject instantiated = Instantiate(
            tilePrefab,
            transform
            );

        instantiated.transform.localPosition = position;

        instantiated.name = "Tile " + numberTiles++;
        print(instantiated + "en la ubicacion" + position);

        TileScript ts = instantiated.GetComponent<TileScript>();

        if (ts == null)
        {
            ts = instantiated.AddComponent<TileScript>();
        }

        ts.rotationSpeed = new Vector3(
            xRotationScaler,
            yRotationScaler,
            0);

        ts.initialX = (int)position.x;
        ts.initialY = (int)position.y;

        tiles.Add(ts);
    }
}
