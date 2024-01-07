using GildedRoseKata;

int? daysOverride = null;

if (args.Length > 0 && int.TryParse(args[0], out int argParsed))
{
    daysOverride = argParsed;
}

Scenario.Run(daysOverride);
