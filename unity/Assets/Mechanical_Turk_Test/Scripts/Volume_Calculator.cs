using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Volume_Calculator : MonoBehaviour
{

        // Start is called before the first frame update
        void Start()
    {

        // float num = 0;
        // print("Hello World " + num + " times.");

        public float SignedVolumeOfTriangle (Vector3 p1, Vector3 p2, Vector3 p3)
        {
            var v321 = p3.x * p2.y * p1.z;
            var v231 = p2.x * p3.y * p1.z;
            var v312 = p3.x * p1.y * p2.z;
            var v132 = p1.x * p3.y * p2.z;
            var v213 = p2.x * p1.y * p3.z;
            var v123 = p1.x * p2.y * p3.z;
            return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
        }

        public float VolumeOfMesh(Mesh mesh)
        {
            var vols = from t in mesh.triangles
                       select SignedVolumeOfTriangle(t.p1, t.p2, t.p3);
            return Math.Abs(vols.Sum());
        }



    }
}
