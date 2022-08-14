using System.Diagnostics;

public class PageNavigationAnalyzerService : IPageNavigationAnalyzerService
{

    private List<string> Routes;
    private List<List<int>> AdjacencyMatrix;

    public PageNavigationAnalyzerService()
    {
        Routes = new();
        AdjacencyMatrix = new();
    }

    public void AddEdge(string fromPath, string toPath)
    {
        var firstIndex = Routes.FindIndex(r => r == fromPath);
        var secondIndex = Routes.FindIndex(r => r == toPath);

        if (firstIndex < 0)
        {
            Routes.Add(fromPath);
            firstIndex = Routes.Count() - 1;
            AdjacencyMatrix.Add(Enumerable.Repeat(0, firstIndex).ToList());
            foreach (var row in AdjacencyMatrix)
            {
                row.Add(0);
            }
        }

        if (secondIndex < 0)
        {
            Routes.Add(toPath);
            secondIndex = Routes.Count() - 1;
            AdjacencyMatrix.Add(Enumerable.Repeat(0, secondIndex).ToList());
            foreach (var row in AdjacencyMatrix)
            {
                row.Add(0);
            }
        }

        AdjacencyMatrix[firstIndex][secondIndex] += 1;
        
        LogMatrix();
    }

    public void LogMatrix()
    {
        for (int i = 0; i < AdjacencyMatrix.Count(); i++)
        {
            Debug.WriteLine(Routes[i]);

            for (int j = 0; j < AdjacencyMatrix.Count(); j++)
            {
                Debug.WriteLine($"  -> '{Routes[j]}': {AdjacencyMatrix[i][j]}");
            }
            Debug.WriteLine("");
        }
    }
}
