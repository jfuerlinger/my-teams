using MyTeams.Core.Contracts;
using MyTeams.Core.Model;
using System.Collections.Generic;

namespace MyTeams.Core.Services
{
  public class TeamsService : ITeamsService
  {
    private List<Team> _teams;

    public TeamsService()
    {
      _teams = new List<Team>
      {
        new Team("POS 5ACIF_AKIF [2019-2020]", new [] { "Allgemein", "10 Termin 14.05.2020", "11 Termin 21.05.2020 (Chrisi Himmelfahrt)" }),
        new Team("DA 2020_21 Stylist", new [] { "Allgemein", "Abstimmungen", "Beurteilung" }),
        new Team("DA 2020_21 Ticketsystem", new [] { "Allgemein", "Abstimmungen", "Beurteilung" }),
      };
    }

    public IEnumerable<Team> Teams => _teams;
  }
}
