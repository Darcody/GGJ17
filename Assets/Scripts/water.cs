using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {

    public Vector2 range = new Vector2(0.1f, 1);
    public float speed = 1;
    float[] randomTimes;
    Mesh mesh;
    Color32 []color;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        int i = 0;
        randomTimes = new float[mesh.vertices.Length];
        color = new Color32[mesh.vertices.Length];
        while (i < mesh.vertices.Length)
        {
            randomTimes[i] = Random.Range(range.x, range.y);

            i++;
        }

    }

    void Update()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int i = 0;
        while (i < vertices.Length)
        {
            vertices[i].y = 1 * Mathf.PingPong(Time.time * speed, randomTimes[i]);
            color[i]=new Color32((byte)Random.Range(0.0f, 1.0f),
                                (byte) Random.Range(0.0f, 1.0f),
                                (byte) Random.Range(0.0f, 1.0f),
                               (byte)  1.0f);
            i++;
        }
        mesh.vertices = vertices;
        mesh.colors32 = color;
    }
}

