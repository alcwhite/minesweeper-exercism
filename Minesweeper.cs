using System;
using System.Collections.Generic;
using System.Linq;

public static class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        if (input == Array.Empty<string>()) return Array.Empty<string>();
        var rowsWithMines = new List<int>();
        int count = 0;
        input.ToList().ForEach(s => 
        {
            if(s.Contains('*')) 
                rowsWithMines.Add(count);
            count++;
        });
        var allCells = input.Select(x => x.ToCharArray()).ToList();
        var cellsWithMines = new List<(int row, int column)>();
        rowsWithMines.ForEach(x => 
        {
            count = 0;
            allCells[x].ToList().ForEach(y => 
            {
                if (y == '*')
                    cellsWithMines.Add((x, count));
                count++;
            });
        });
        
        var newCells = allCells.Select((cellRow, rowIndex) => 
        {
            return cellRow.Select<char, char>((cell, columnIndex) => 
            {
                if (cell == '*') return '*';
                int adjacentMineCount = 0;
                if (cellsWithMines.Contains((rowIndex - 1, columnIndex - 1))) adjacentMineCount++;
                if (cellsWithMines.Contains((rowIndex - 1, columnIndex))) adjacentMineCount++;
                if (cellsWithMines.Contains((rowIndex - 1, columnIndex + 1))) adjacentMineCount++;
                if (cellsWithMines.Contains((rowIndex, columnIndex - 1))) adjacentMineCount++;
                if (cellsWithMines.Contains((rowIndex, columnIndex + 1))) adjacentMineCount++;
                if (cellsWithMines.Contains((rowIndex + 1, columnIndex - 1))) adjacentMineCount++;
                if (cellsWithMines.Contains((rowIndex + 1, columnIndex))) adjacentMineCount++;
                if (cellsWithMines.Contains((rowIndex + 1, columnIndex + 1))) adjacentMineCount++;
                
                return adjacentMineCount == 0 ? ' ' : char.Parse(adjacentMineCount.ToString());
            });
        });

        return newCells.Select(x => new string(x.ToArray())).ToArray();
        
    }
}
