using System;
using System.Collections.Generic;

struct FatStruct
{
    public long M00;
    public long M01;
    public long M02;
    public long M03;
    public long M04;
    public long M05;
    public long M06;
    public long M07;
    public long M08;
    public long M09;
    public long M10;
}

class FatClass
{
    public long M00;
    public long M01;
    public long M02;
    public long M03;
    public long M04;
    public long M05;
    public long M06;
    public long M07;
    public long M08;
    public long M09;
    public long M10;
}

public static class Hoge
{
    public static void HogeHogeHogeHogeHogeHoge()
    {
        var array = new[] { 1, 2, 3, 4, 5 };
        foreach (var e in array)
        {
            Console.WriteLine(e.ToString());
        }

        var list = new List<int>() {100, 200, 300, 400, 500};
        foreach (var e in list)
        {
            Console.WriteLine(e.ToString());
        }

        var s = new FatStruct();
        Console.WriteLine(PassValue(s).ToString());

        var c = new FatClass();
        Console.WriteLine(PassRef(c).ToString());
    }

    static long PassValue(FatStruct v)
    {
        return v.M00 + v.M10 + 1;
    }

    static long PassRef(FatClass v)
    {
        return v.M00 + v.M10 + 1;
    }
}
