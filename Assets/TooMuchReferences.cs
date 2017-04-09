using UnityEngine;

public class TooMuchReferences : MonoBehaviour
{
    [SerializeField]
    bool UsingStruct;

    [SerializeField]
    int NumberOfTrials;

    static class RootObject
    {
        public static ParentWithClass ParentWithClass = new ParentWithClass();
        public static ParentWithStruct ParentWithStruct = new ParentWithStruct();
    }

    class ParentWithClass
    {
        public Child1WithClass Child = new Child1WithClass();
    }

    class Child1WithClass
    {
        public Child2WithClass Child = new Child2WithClass();
    }

    class Child2WithClass
    {
    }

    struct ParentWithStruct
    {
        public Child1WithStruct Child;
    }

    struct Child1WithStruct
    {
        public Child2WithStruct Child;
    }

    struct Child2WithStruct
    {
    }

    ParentWithClass[] _parentWithClasses;
    Child1WithClass[] _child1WithClasses;
    Child2WithClass[] _child2WithClasses;

    ParentWithStruct[] _parentWithStructs;
    Child1WithStruct[] _child1WithStructs;
    Child2WithStruct[] _child2WithStructs;

    void Start()
    {
        _parentWithClasses = new[]
        {
            new ParentWithClass(),
            new ParentWithClass(),
            new ParentWithClass(),
            new ParentWithClass(),
            new ParentWithClass(),
        };
        _child1WithClasses = new[]
        {
            new Child1WithClass(),
            new Child1WithClass(),
            new Child1WithClass(),
            new Child1WithClass(),
            new Child1WithClass(),
        };
        _child2WithClasses = new[]
        {
            new Child2WithClass(),
            new Child2WithClass(),
            new Child2WithClass(),
            new Child2WithClass(),
            new Child2WithClass(),
        };

        _parentWithStructs = new[]
        {
            new ParentWithStruct(),
            new ParentWithStruct(),
            new ParentWithStruct(),
            new ParentWithStruct(),
            new ParentWithStruct(),
        };
        _child1WithStructs = new[]
        {
            new Child1WithStruct(),
            new Child1WithStruct(),
            new Child1WithStruct(),
            new Child1WithStruct(),
            new Child1WithStruct(),
        };
        _child2WithStructs = new[]
        {
            new Child2WithStruct(),
            new Child2WithStruct(),
            new Child2WithStruct(),
            new Child2WithStruct(),
            new Child2WithStruct(),
        };
    }

    void Update()
    {
        for (var i = 0; i < NumberOfTrials; i++)
        {
            if (UsingStruct)
            {
                var parent = new ParentWithStruct();
                var child1 = new Child1WithStruct();
                var child2 = new Child2WithStruct();

                child1.Child = child2;
                parent.Child = child1;
                RootObject.ParentWithStruct = parent;
            }
            else
            {
                var parent = new ParentWithClass();
                var child1 = new Child1WithClass();
                var child2 = new Child2WithClass();

                child1.Child = child2;
                parent.Child = child1;
                RootObject.ParentWithClass = parent;
            }
        }
    }
}
