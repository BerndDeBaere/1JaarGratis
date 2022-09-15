using System.ComponentModel.DataAnnotations;

namespace EenJaarGratis.Service.Storage.Domain;

public class BaseEntity
{
    [Key] public int Id { get; set; }
}