﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SLDocument sl = new SLDocument();

            Random rand = new Random();
            int i, j;
            for (i = 1; i <= 20; ++i)
            {
                for (j = 1; j <= 10; ++j)
                {
                    sl.SetCellValue(i, j, 200 * rand.NextDouble());
                }
            }

            SLConditionalFormatting cf;

            cf = new SLConditionalFormatting("B2", "H5");
            cf.SetIconSet(IconSetValues.ThreeSymbols);
            sl.AddConditionalFormatting(cf);

            cf = new SLConditionalFormatting("D7", "G12");
            // Use the ThreeArrows icon set
            // "false" - don't reverse icon order
            // "false" - don't show only icons (show values too!)
            // "true" - it's greater than or equal to (instead of strictly greater than)
            // "100" - >= 100
            // Number - meaning "100" refers to actual value
            // "true" - it's greater than or equal to (instead of strictly greater than)
            // "150" - >= 150
            // Number - meaning "150" refers to actual value
            cf.SetCustomIconSet(SLThreeIconSetValues.ThreeArrows, false, false,
                true, "100", SLConditionalFormatRangeValues.Number,
                true, "150", SLConditionalFormatRangeValues.Number);
            sl.AddConditionalFormatting(cf);

            cf = new SLConditionalFormatting("C15", "J18");
            // Use the FiveRating icon set
            // Reverse the icon order!
            // Show only icons!
            // The whole range uses percentile values.
            // So it's:
            // 1st icon - whatever's before the condition for 2nd icon
            // 2nd icon > 15 percentile
            // 3rd icon > 35 percentile
            // 4th icon >= 67 percentile
            // 5th icon > 80 percentile
            cf.SetCustomIconSet(SLFiveIconSetValues.FiveRating, true, true,
                false, "15", SLConditionalFormatRangeValues.Percentile,
                false, "35", SLConditionalFormatRangeValues.Percentile,
                true, "67", SLConditionalFormatRangeValues.Percentile,
                false, "80", SLConditionalFormatRangeValues.Percentile);
            sl.AddConditionalFormatting(cf);

            sl.SaveAs("ConditionalFormatIconSet.xlsx");

            Console.WriteLine("End of program");
            Console.ReadLine();
        }
    }
}
