using UnityEngine;

public class TooMuchAllocating : MonoBehaviour
{
    class ValueWithClass
    {
        public float X;
        public float Y;
        public float Z;

        public static ValueWithClass RandomGenerate()
        {
            return new ValueWithClass()
            {
                X = Random.Range(-100f, 100f),
                Y = Random.Range(-100f, 100f),
                Z = Random.Range(-100f, 100f),
            };
        }
    }

    struct ValueWithStruct
    {
        public float X;
        public float Y;
        public float Z;

        public static ValueWithStruct RandomGenerate()
        {
            return new ValueWithStruct()
            {
                X = Random.Range(-100f, 100f),
                Y = Random.Range(-100f, 100f),
                Z = Random.Range(-100f, 100f),
            };
        }
    }

    [SerializeField]
    bool UsingStruct;

    [SerializeField]
    int NumberOfAllocating = 1;

    Transform _transform;

    void Start()
    {
        _transform = transform;
    }

	void Update()
	{
	    for (var i = 0; i < NumberOfAllocating; i++)
	    {
	        if (UsingStruct)
	        {
	            var s = ValueWithStruct.RandomGenerate();
	            _transform.position = new Vector3(s.X, s.Y, s.Z);
	        }
	        else
	        {
	            var c = ValueWithClass.RandomGenerate();
	            _transform.position = new Vector3(c.X, c.Y, c.Z);
	        }
	    }
	}
}
