﻿using GildedRoseKata;
using System;

namespace GildedRoseTests;

public static class TextTestFixture
{
    public static void Main(string[] args)
    {
        int? daysOverride = null;

        if (args.Length > 0 && int.TryParse(args[0], out int argParsed))
        {
            daysOverride = argParsed;
        }

        var output = Scenario.Run(daysOverride);
        Console.Write(output);
    }
}
