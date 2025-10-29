using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'connectedCell' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
     */

    public static int connectedCell(List<List<int>> matrix)
    {
        int n = matrix.Count;
        int m = matrix[0].Count;
        bool[,] visited = new bool[n, m];

        int maxRegion = 0;

        int[] dx = {-1, -1, -1, 0, 0, 1, 1, 1};
        int[] dy = {-1, 0, 1, -1, 1, -1, 0, 1};

        int DFS(int x, int y)
    {
        visited[x, y] = true;
        int size = 1;

        for (int dir = 0; dir < 8; dir++)
        {
            int nx = x + dx[dir];
            int ny = y + dy[dir];

            if (nx >= 0 && nx < n && ny >= 0 && ny < m && matrix[nx][ny] == 1 && !visited[nx, ny])
            {
                size += DFS(nx, ny);
            }
        }
        return size;
    }
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (matrix[i][j] == 1 && !visited[i, j])
            {
                int regionSize = DFS(i, j);
                if (regionSize > maxRegion)
                    maxRegion = regionSize;
            }
        }
    }
    return maxRegion;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        int result = Result.connectedCell(matrix);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
