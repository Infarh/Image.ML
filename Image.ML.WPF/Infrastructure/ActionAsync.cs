using System.Threading.Tasks;

namespace Image.ML.WPF.Infrastructure
{
    public delegate Task ActionAsync();

    public delegate Task ActionAsync<in T>(T arg);
}
