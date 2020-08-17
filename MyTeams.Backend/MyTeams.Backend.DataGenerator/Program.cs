using CommandLine;
using MyTeams.Backend.DataGenerator.Infrastructure;
using System;

namespace MyTeams.Backend.DataGenerator
{
  class Program
  {
    static int Main(string[] args)
    {
      DataGenerator dataGenerator = new DataGenerator();

      try
      {
        Parser.Default.ParseArguments<
          InitOptions,
          CleanupOptions,
          GenerateOptions>(args)
          .MapResult(
          async (InitOptions o) => await dataGenerator.PerformInit(),
          async (CleanupOptions o) => await dataGenerator.PerformCleanup(),
          async (GenerateOptions o) => await dataGenerator.PerformGeneration(o),
          errors => throw new Exception("Parser error"))
            .GetAwaiter().GetResult();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return 1;
      }

      return 0;
    }
  }
}
