using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryMLearning.Persistence.Models.Map
{
    [Table("ClassificationDataSetSmapleDoubleTuple")]
    public class ClassificationDataSetSmapleDoubleTupleMap
    {
        [Key]
        public int Id { get; set; }

        public int DoubleTupleId { get; set; }

        [ForeignKey(nameof(DoubleTupleId))]
        public DoubleTupleDbEntity DoubleTuple { get; set; }

        public int ClassificationDataSetSmapleId { get; set; }

        [ForeignKey(nameof(ClassificationDataSetSmapleId))]
        public ClassificationDataSetSmapleDbEntity ClassificationDataSetSmaple { get; set; }

        [Column("SeqNum")]
        public int SequentialNumber { get; set; }
    }
}