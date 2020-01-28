using System;
using System.Collections.Generic;
using System.Linq;

public static class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        var rowsWithMines = new List<int>();
        input.Where((s, i) => 
        {
            if(s.Contains('*')) 
                rowsWithMines.Add(i);
            return true;
        });
        var allCells = input.Select(x => x.ToCharArray()).ToList();
        var cellsWithMines = new List<(int row, int column)>();
        rowsWithMines.ForEach(x => 
        {
            allCells[x].Where((y, i) => 
            {
                if (y == '*')
                    cellsWithMines.Add((x, i));
                return true;
            });
        });
        var rows = input.Length;
        return input == Array.Empty<string>() ? Array.Empty<string>() : allCells.Select(x => new string(x)).ToArray();
        
    }
}
