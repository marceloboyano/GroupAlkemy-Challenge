using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Entities;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
    DateTime? DeletedDate { get; set; }
}

public abstract class SoftDeleteEntity : ISoftDelete
{
    [Column("IsDeleted")] public bool IsDeleted { get; set; } = false;

    [Column("DeletedDate")] public DateTime? DeletedDate { get; set; }
}