using CommandLine;

namespace MyTeams.Backend.DataGenerator.Infrastructure
{
  [Verb("init", HelpText = "Init the database (removes old instance if exists).")]
  class InitOptions
  {
  }

  [Verb("cleanup", HelpText = "Clone a repository into a new directory.")]
  class CleanupOptions
  {
  }

  [Verb("generate", isDefault: true, HelpText = "Perform clean up.")]
  class GenerateOptions
  {
    [Option('i', "withinit", Default = false, HelpText = "Resets the database")]
    public bool WithInitialization { get; set; }

    [Option('e', "endless", Default = false, HelpText = "Geneate endless data")]
    public bool IsEndless { get; set; }

    [Option('g', "generations", Default = 5, HelpText = "Number of generations")]
    public int NrOfGenerations { get; set; }
  }

}
