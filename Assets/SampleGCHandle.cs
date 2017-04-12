using System;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class SampleGCHandle : MonoBehaviour
{
    class AnyClass
    {
        public int A;
        public int B;
        public int C;

        public AnyClass(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
    }

    struct AnyStruct
    {
        public int A;
        public int B;
        public int C;

        public AnyStruct(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
    }

    static AnyClass staticAnyClass = new AnyClass(100, 200, 300);

    void Start ()
    {
        var thread = new Thread(AnotherThread);
        thread.Start();
        thread.Join();
        var anyClassForGCHandle = new AnyClass(100, 200, 300);
        var gcHandle = GCHandle.Alloc(anyClassForGCHandle);

        var anyStruct = new AnyStruct(100, 200, 300);
        GC.Collect();
    }

    static void AnotherThread()
    {
        var anyClassLocal = new AnyClass(100, 200, 300);
    }
}