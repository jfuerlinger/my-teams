using MyTeams.Backend.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MyTeams.Backend.Core.Model
{
  public class EntityObject : IEntityObject
  {
    public int Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
  }
}