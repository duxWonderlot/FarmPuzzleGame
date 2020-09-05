
 
namespace UnityEngine
{
    using System.Collections;
    using System.Collections.Generic;
    //using UnityEngine;

    public class Cricles : MonoBehaviour
    {
        Vector3[] verts;
        Vector2[] newUV;
        int[] mTris;
        [SerializeField]
        Material mat;
        [SerializeField]
        [Range(-10, 10)]
        float A, B, C, D, E, F, G, H,I,I2;
        private void Update()
        {
            verts = new Vector3[4];
            newUV = new Vector2[4];
            mTris = new int[6];

            Mesh mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<Renderer>().material = mat;
            verts[0] = new Vector3(A, 0.0f, B);
            verts[1] = new Vector3(C, I, D);
            verts[2] = new Vector3(-E, I2, -F);
            verts[3] = new Vector3(G, 0.0f, -H);
 
            newUV[0] = new Vector2(0.0f, 0.0f);
            newUV[1] = new Vector2(1.0f, 0.0f);
            newUV[2] = new Vector2(0.0f, 1.0f);
            newUV[3] = new Vector2(1.0f, 1.0f);

            mTris[0] = 0;
            mTris[1] = 1;
            mTris[2] = 3;

            mTris[3] = 0;
            mTris[4] = 3;
            mTris[5] = 2;

            mesh.vertices = verts;
            mesh.uv = newUV;
            mesh.triangles = mTris;

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
        }
    }
}
